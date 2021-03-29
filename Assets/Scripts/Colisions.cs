using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisions : MonoBehaviour
{
    public ParticleSystem particles;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!particles)
            return;
        Debug.Log("OnCollisionEnter2D"+ col.relativeVelocity.magnitude);
        var x = particles.emission;
        x.rateOverTime = col.relativeVelocity.magnitude;
        
        particles.Play();
    }
}
