using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{   
    // Basic Movement Variables
    Rigidbody2D _rigidbody;
    Animator _animator;
    int speed = 10;
    int jumpForce = 900;

    // Jumping Variables
    public LayerMask groundLayer;
    public Transform feetPos;
    float groundCheckDist = 0.3f;
    bool isGrounded = false;

    // Shooting Variables
    public GameObject bulletPrefab;
    public Transform gunPos;
    int bulletForce = 250;

    // Death Mechanic Variables
    

    // Audio
    AudioSource _audioSource;
    public AudioClip shootSound;
    public AudioClip deathSound;
    public AudioClip damageSound;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        PublicVars.isAlive = true;
    }

    private void FixedUpdate() 
    {
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundCheckDist, groundLayer);
        _animator.SetBool("Grounded", isGrounded);

        // Death Mechanic
        if(PublicVars.isAlive && (transform.position.y <-10))
        {
            PublicVars.isAlive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void Update()
    {
        // Left, Right Movement
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));

        // Jumping
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, jumpForce));
            _audioSource.Pause();
        }

        // Shooting
        if(Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("Shoot");
            GameObject newBullet = Instantiate(bulletPrefab, gunPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce * transform.localScale.x, 0));
            _audioSource.PlayOneShot(shootSound);
        }

        // Flipping Sprite
        if (xSpeed>0 && transform.localScale.x<0 || xSpeed<0 && transform.localScale.x>0){
            transform.localScale *= new Vector2(-1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Death if Spike or Enemy
        if(other.CompareTag("Spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Score chante if Candy
        if (other.CompareTag("Candy"))
        {
            //_audioSource.clip = candySound;
            _audioSource.Play();
            
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            PublicVars.isAlive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
