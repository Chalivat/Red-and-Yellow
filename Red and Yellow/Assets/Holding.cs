using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Holding : MonoBehaviour
{
    [Header("Main Informations")]
    public GameObject Anchor;
    public float checkDistance;
    

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void CheckForObstacle()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.forward,out hit,checkDistance))
        {
            
        }
    }
}
