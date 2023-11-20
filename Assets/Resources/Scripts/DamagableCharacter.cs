using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableCharacter : MonoBehaviour, IDamagable
{
    Rigidbody2D rb;
    new Collider2D collider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnHit(int damage, Vector2 knockback)
    {
        Debug.Log($"OnHit({damage}, {knockback})");
        Health -= damage;
        rb.AddForce(knockback);
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    public int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            Debug.Log($"Set heath from {health} to {value}.");
            if (value < health)
            {
                gameObject.BroadcastMessage("OnDamage");
            }
            health = value;
            if (health <= 0)
            {
                gameObject.BroadcastMessage("OnDie");
                targetable = false;
            }
        }
    }

    bool targetable;
    public bool Targetable
    {
        get
        {
            return targetable;
        }
        set
        {
            targetable = value;
            if (!targetable)
            {
                rb.simulated = false;
            }
        }
    }
}
