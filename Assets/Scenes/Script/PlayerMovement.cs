using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameManager gm;
    private Rigidbody2D body;
    private Animator animator;

    float horizontal;
    float vertical;

    public float runSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        horizontal = 0;
        vertical = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("speedH", horizontal);
        animator.SetFloat("speedV", vertical);
    }
    private void FixedUpdate()
    {

        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= 0.7f;
            vertical *= 0.7f;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
