using UnityEngine;

public class RigidBodyWorm : MonoBehaviour
{
    public Transform[] wormParts;
    public Vector3[] smoothRefs;
    public Vector3[] wormPartsPositions;
    public float targetDistance;
    public float smoothTime;
    public float forceMultiplier = 10f;
    public float jointSpringMultiplier = 1;
    HingeJoint2D joint;
    Rigidbody2D myRigidbody;
    void Start()
    {
        smoothRefs = new Vector3[wormParts.Length];
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        joint = transform.GetComponent<HingeJoint2D>();
    }

    void FixedUpdate()
    {
        var j = joint.connectedAnchor;
        j.x = Mathf.Lerp(-1, -(myRigidbody.velocity.magnitude * jointSpringMultiplier), Time.fixedDeltaTime);
        joint.connectedAnchor = j;
        
        for (int i=1; i < wormParts.Length; i++)
        {
            var dest = wormParts[i - 1].localPosition + wormParts[0].right * wormParts[i - 1].transform.localScale.x;
            var f = Vector3.SmoothDamp(wormParts[i].localPosition, (dest), ref smoothRefs[i], smoothTime / forceMultiplier);

            //Debug.DrawRay(wormParts[i].localPosition, dest - wormParts[i].localPosition,Color.green);
            //Debug.DrawRay(wormParts[i].localPosition, wormParts[i].InverseTransformPoint(dest) * forceMultiplier * Time.fixedDeltaTime, Color.blue);
            wormParts[i].GetComponent<Rigidbody2D>().MovePosition(f);
            //wormParts[i].GetComponent<Rigidbody2D>().velocity = wormParts[i].InverseTransformPoint(dest) * forceMultiplier * Time.fixedDeltaTime; // ( wormParts[i - 1].localPosition - wormParts[i].localPosition) * forceMultiplier *Time.fixedDeltaTime;// transform.InverseTransformDirection(f * Time.deltaTime * forceMultiplier); 
        }
    }
}
