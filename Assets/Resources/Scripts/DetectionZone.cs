using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public float detectRadius;
    public LayerMask detectLayerMask;
    private Collider2D detectedObj;

    public Collider2D getDetectedObj()
    {
        return detectedObj;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        detectedObj = Physics2D.OverlapCircle(transform.position, detectRadius, detectLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }

}
