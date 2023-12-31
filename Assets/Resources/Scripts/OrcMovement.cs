using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    Rigidbody2D body;
    public float moveSpeed;
    Animator animator;
    SpriteRenderer spriteRenderer;

    DetectionZone detectionZone;

    public WeaponProperty wp;
    float lastAttack = 0f;
    const float attackInterval = 2.0f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        detectionZone = GetComponent<DetectionZone>();
    }

    private void FixedUpdate()
    {
        Collider2D target = detectionZone.getDetectedObj();
        if (target == null)
        {
            animator.SetBool("isWalking", false);
            return;
        }
        Vector2 direction = target.transform.position - transform.position;
        //if (direction.magnitude > detectionZone.detectRadius)
        //{
        //    animator.SetBool("isWalking", false);
        //    Debug.Log("Object detected but distanct too far.");
        //    return;
        //}
        body.AddForce(direction.normalized * moveSpeed);
        animator.SetBool("isWalking", true);
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void OnDamage()
    {
        animator.SetTrigger("isAttacked");
    }

    void OnDie()
    {
        animator.SetBool("isDead", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - lastAttack < attackInterval)
        {
            return;
        }
        lastAttack = Time.time;

        Collider2D collider = collision.collider;
        IDamagable dmg = collider.GetComponent<IDamagable>();

        Debug.Log($"orc collides with {collider.gameObject.name}");
        if (dmg != null && collider.tag == "Player")
        {
            Vector2 direction = collider.transform.position - transform.position;
            dmg.OnHit(wp.attackDamage, direction.normalized * wp.knockbackForce);
        }
    }
}
