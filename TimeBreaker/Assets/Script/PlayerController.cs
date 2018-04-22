using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    float h, v;
    float moveSpeed = 10;
    int jumpSpeed = 1000;
    bool onGround;
    SpriteRenderer myImage;
    public SpriteRenderer gun;

    void Start()
    {
        myImage = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (v == 1 && onGround)
        {
            onGround = false;
            rb.AddForce(Vector3.up * jumpSpeed);
        }
        if (rb.velocity.y < 0) rb.gravityScale = 13;
    }

    private void FixedUpdate()
    {
        if (h == 0)
        {
            if (anim.GetBool("Walking") == true) anim.SetBool("Walking", false); // Way to long since I have worked with anim! This doesn't seem right
            return;
        }

        if (transform.localScale.x == 1 && h == 1) // like a true master...
        {
            transform.localScale = new Vector3(-1, 1, 1);
            gun.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        }
        else if (transform.localScale.x == -1 && h == -1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            gun.transform.localScale = new Vector3(-0.3f, -0.3f, 0.3f); // to much hazzle!
        } 

        if (anim.GetBool("Walking") == false) anim.SetBool("Walking", true); // should be in update
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.gravityScale = 7;
            onGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (rb.velocity.y != 0) return;
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.gravityScale = 7;
            onGround = true;
        }
    }
}
