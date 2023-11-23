using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Testing : MonoBehaviour
{
    public int damage = 10;

    void OnFire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0;
        if (Random.Range(1, 100) < 30)
        {
            DamagePopup.Create(mousePosition, damage * 2, true);
        }
        else
        {
            DamagePopup.Create(mousePosition, damage, false);
        }
    }
}
