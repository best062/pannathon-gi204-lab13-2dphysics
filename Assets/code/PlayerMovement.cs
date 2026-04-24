using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float move;
    public float JumpForce;
    public bool IsJumping;
    
    Rigidbody2D rb2b;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2b = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2b.linearVelocity = new Vector2(move * Speed, rb2b.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rb2b.AddForce(new Vector2(rb2b.linearVelocity.x, JumpForce));
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
}

