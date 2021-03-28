using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    /// <summary>
    /// Generate chunks of background (3 maybe 5)
    /// Chunks are made with children that will have paralax on them
    /// Check player position. If > than scenn height - create new chunk over existing chunks. Or move lower chunk up
    /// 
    /// </summary>



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        foreach (Transform child in transform)
        {
            
        }
    }
}
