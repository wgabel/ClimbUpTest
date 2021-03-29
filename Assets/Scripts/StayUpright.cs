using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayUpright : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private int angleX = 0;
    void Update()
    {
        angleX = Mathf.Clamp(angleX, 1, 45);
        transform.eulerAngles = new Vector3(angleX, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
