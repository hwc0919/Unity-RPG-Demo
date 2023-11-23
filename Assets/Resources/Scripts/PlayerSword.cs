using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    Vector3 position;
    public WeaponProperty wp;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.localPosition;
    }

    void FacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            transform.localPosition = new Vector3(-position.x, position.y, position.z);
        }
        else
        {
            transform.localPosition = position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();
        if (damagable != null)
        {
            Vector3 parentPosition = transform.parent.position;
            Vector2 direction = collision.transform.position - parentPosition;

            int damage = wp.attackDamage;
            bool isCritical = Random.Range(0, 100) < 30;
            if (isCritical)
            {
                damage *= 2;
            }
            damagable.OnHit(damage, direction.normalized * wp.knockbackForce);
            DamagePopup.Create(collision.transform.position, damage, isCritical);
        }
    }
}
