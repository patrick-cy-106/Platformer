using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    public GameObject explosion;
    public int speed = 2;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    Transform player;
    Rigidbody2D _rigidbody;
    BoxCollider2D _collider;
    Animator _animator;
    public Transform castPoint;
    float groundCheckDist = 0.3f;
    bool isGrounded;
    bool isWall;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    private void FixedUpdate() 
    {
        isGrounded = Physics2D.OverlapCircle(castPoint.position, groundCheckDist, groundLayer);    
        isWall = Physics2D.OverlapCircle(castPoint.position, groundCheckDist, wallLayer);
    }

    void Update()
    {
        if (!isGrounded || isWall)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
        _rigidbody.velocity = new Vector2(speed * -transform.localScale.x, _rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(_collider);
            Destroy(other.gameObject);
            _animator.SetTrigger("Death");
            Destroy(gameObject, 0.3f);
        }
    }
}
