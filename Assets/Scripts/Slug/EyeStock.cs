using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeStock : MonoBehaviour
{
    public Transform eye;
    public Transform targetHead;
    LineRenderer lineRenderer;
    
    void Start()
    {
        lineRenderer = gameObject.GetComponentInChildren(typeof(LineRenderer), true) as LineRenderer;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, eye.position);
        lineRenderer.SetPosition(1, targetHead.position);
    }
}
