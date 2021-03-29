using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Transform head;
    public Transform eye;
    public float distanceFromHead = 1f;
    public float verticalMove = 0;
    Vector3 smoothRef;

    public float smoothTime = 0.5f;

    public float wiggleMultiplier;

    void FixedUpdate()
    {
        var dest = head.localPosition + (Vector3.up * distanceFromHead) + (Vector3.right * verticalMove);
        var f = Vector3.SmoothDamp(eye.localPosition, (dest), ref smoothRef, smoothTime );
        eye.GetComponent<Rigidbody2D>().MovePosition(f);     
    }
}
