using UnityEngine;

public class Worm : MonoBehaviour
{
    public Transform[] wormParts;
    public Vector3[] wormPartsPositions;
    public Vector3[] smoothRefs;
    public float targetDistance;
    public float smoothTime;
    public void Start()
    {
        wormPartsPositions = new Vector3[wormParts.Length];
        smoothRefs = new Vector3[wormParts.Length];
    }
    public void Update()
    {
        wormPartsPositions[0] = wormParts[0].transform.position;

        for (int i = 1; i < wormPartsPositions.Length; i++)
        {
            wormPartsPositions[i] = Vector3.SmoothDamp(wormPartsPositions[i], wormPartsPositions[i-1] + wormParts[0].right * targetDistance, ref smoothRefs[i], smoothTime);
            wormParts[i].transform.position = wormPartsPositions[i];
        }
    }
}
