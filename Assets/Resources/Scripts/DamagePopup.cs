using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Vector3 moveDirection;
    public float lifeTime;
    public float fadeOutSpeed;
    private int value;

    private static int sortingOrder = 0;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public static DamagePopup Create(Vector3 position, int value, bool isCritical)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.Instance.damagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(value, isCritical);
        return damagePopup;
    }

    void Setup(int value, bool isCritical)
    {
        moveDirection = new Vector3(.7f, 1);
        textMesh.text = value.ToString();
        textMesh.sortingOrder = ++sortingOrder;

        if (isCritical)
        {
            textMesh.fontSize += 2;
            textMesh.color = Color.red;
        }
    }

    private void Update()
    {
        transform.position += moveDirection * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            // Start to fade out
            Color textColor = textMesh.color;
            textColor.a -= fadeOutSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
