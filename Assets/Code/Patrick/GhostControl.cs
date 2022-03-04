using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    public GameObject explosion;
    //Animator _animator;
    void Start()
    {
        //_animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            //_animator.SetTrigger("Death");
            Destroy(gameObject, 0.3f);
        }
    }
}
