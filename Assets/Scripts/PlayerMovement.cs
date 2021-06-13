using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameManager gm;
    private Rigidbody2D body;
    private Animator animator;
    public SpriteRenderer spriteRenderer;

    float horizontal;
    float vertical;

    public bool isMind;
    float runSpeed = 1f;

    private bool flipSprite, lockFlip;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        //spriteRenderer = GameObject.FindObjectOfType<SpriteRenderer>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        horizontal = 0;
        vertical = 0;
        flipSprite = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.playerCanMove) {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            animator.SetFloat("speedH", horizontal);
            animator.SetFloat("speedV", vertical);

            if (horizontal < 0)
            {
                flipSprite = true;
            }
            else if (horizontal > 0)
            {
                flipSprite = false;
            }

            if (horizontal == 0)
            {
                lockFlip = true;
            }
            else
            {
                lockFlip = false;
            }
        }        
    }
    private void FixedUpdate()
    {
        if (gm.playerCanMove)
        {
            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= 0.7f;
                vertical *= 0.7f;
            }

            Vector2 movement;

            if ((gm.normalWorld && isMind) || (!gm.normalWorld && !isMind))
            {
                movement = new Vector2(-1 * horizontal * runSpeed, vertical * runSpeed);
            }
            else
            {
                movement = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            }

            if (!lockFlip && ((gm.normalWorld && isMind) || (!gm.normalWorld && !isMind)))
            {
                spriteRenderer.flipX = !flipSprite;
            }
            else if (!lockFlip)
            {
                spriteRenderer.flipX = flipSprite;
            }

            body.velocity = movement;
        }
    }
}
