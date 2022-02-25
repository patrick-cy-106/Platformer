using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    Rigidbody2D _rigidbody;
    int speed = 10;
    int jumpForce = 800;

    public LayerMask groundLayer;
    public Transform feetPos;
    float groundCheckDist = 0.3f;
    bool isGrounded = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundCheckDist, groundLayer);
    }

    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
}
