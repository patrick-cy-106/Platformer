using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{   
    // Basic Movement Variables
    Rigidbody2D _rigidbody;
    int speed = 10;
    int jumpForce = 800;

    // Jumping Variables
    public LayerMask groundLayer;
    public Transform feetPos;
    float groundCheckDist = 0.3f;
    bool isGrounded = false;

    // Shooting Variables
    public GameObject bulletPrefab;
    public Transform gunPos;
    int bulletForce = 1000;

    // Death Mechanic Variables
    bool isAlive = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundCheckDist, groundLayer);

        // Death Mechanic
        if(isAlive && (transform.position.y <-10))
        {
            isAlive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void Update()
    {
        // Left, Right Movement
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

        // Jumping
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }

        // Shooting
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bulletPrefab, gunPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce * transform.localScale.x, 0));
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
            // _audioSource.clip = candySound;
            // _audioSource.Play();
            
            Destroy(other.gameObject);
            //score++;
            //scoreUI.text = "Candy Collected: " + score + "/4";
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
