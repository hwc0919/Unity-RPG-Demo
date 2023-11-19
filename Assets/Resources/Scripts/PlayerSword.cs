using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    Vector3 position;

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
}
