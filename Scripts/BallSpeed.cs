using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeed : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 15f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Cleaning",30f);
    }

    void Cleaning()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
        rb.velocity = rb.velocity.normalized * moveSpeed;      
    }
}
