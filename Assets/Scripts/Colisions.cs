using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisions : MonoBehaviour
{

    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D"+ col.relativeVelocity.magnitude);
        var x = particles.emission;
        x.rateOverTime = col.relativeVelocity.magnitude;
        
        particles.Play();
    }
}
