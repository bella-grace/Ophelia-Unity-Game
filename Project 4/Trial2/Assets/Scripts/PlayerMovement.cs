using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool Grounded;
    private bool isRunning;
    private bool isDucking;

    private void Awake()
    {
        //get references from game 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
         
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //flip player left/right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && Grounded)
            Jump();

        //Hold Z to Run
        if (Input.GetKey(KeyCode.Z) && Grounded)
        {
            Run();

        } else {
            isRunning = false;
            speed = 5;
        }

        //Hold shift to duck
        if (Input.GetKey(KeyCode.LeftShift) && Grounded)
        {
            Duck();
        } else
        {
            isDucking = false;
        }

        //set animations
        anim.SetBool("Walking", horizontalInput != 0);
        anim.SetBool("Grounded", Grounded);
        anim.SetBool("Run", isRunning);
        anim.SetBool("Duck", isDucking);
    }

    private void Duck()
    {
        anim.SetTrigger("Duck");
        isDucking = true;
    }

    private void Run()
    {
        speed = 10;
        anim.SetTrigger("Run");
        isRunning = true;
        
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");
        Grounded = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
            Grounded = true;
    }
}
