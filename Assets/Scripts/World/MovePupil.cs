using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePupil : MonoBehaviour
{
    public Transform eye;
    public Transform pupil;
    public float pupilMaxDistance;
    private Vector3 mousePosition;
    private Vector3 directionToMouse;
    private Vector3 wantedDirectionClamped;

    public float maxScale;
    private float initialScale;
    public Rigidbody2D mainRigidbody;
    // Update is called once per frame
    private void Start()
    {
        initialScale = pupil.localScale.x;
    }
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        directionToMouse = mousePosition - eye.localPosition;
        wantedDirectionClamped = Vector3.ClampMagnitude(directionToMouse, pupilMaxDistance);
        pupil.position = eye.position + wantedDirectionClamped;
        
        float newScale = Mathf.Clamp(mainRigidbody.velocity.sqrMagnitude, initialScale, maxScale);
        float x = Mathf.Abs(Mathf.Lerp(pupil.localScale.x, newScale, Time.deltaTime));
        pupil.localScale = new Vector3(x, x, x);
    }
}
