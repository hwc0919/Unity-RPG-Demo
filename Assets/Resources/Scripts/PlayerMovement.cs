using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 moveInput;
    public float moveSpeed;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.AddForce(moveInput * moveSpeed);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (moveInput == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("FacingRight", true);
            }
            else if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("FacingRight", false);
            }
        }
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    void OnDamage()
    {
        animator.SetTrigger("isAttacked");
    }

    void OnDie()
    {
        animator.SetBool("isDead", true);
    }
}
