using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    //Movement Variables
    public float moveSpeed;
    public float horizontalInput;
    public float inputVertical;

    //Jumping
    public bool isOnGround = true;
    public float jumpForce;

    //Game Manager
    public GameManager gm;

    public Animator ai;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        ai = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime);
        inputVertical = Input.GetAxis("Vertical");
        

        //Flip if facing left
        if (horizontalInput < 0)
        {
            sr.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            sr.flipX = false;
        }

        //Jump
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    private void FixedUpdate()
    {
        if (horizontalInput != 0 || inputVertical != 0)
        {
            if (horizontalInput != 0 && inputVertical != 0)
            {
                horizontalInput *= moveSpeed;
                inputVertical *= moveSpeed;
            }

            rb.velocity = new Vector2(horizontalInput * moveSpeed, inputVertical * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    public void Hurt()
    {
        gm.Respawn();
    }
}
