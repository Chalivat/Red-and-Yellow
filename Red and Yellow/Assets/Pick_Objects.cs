using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Objects : MonoBehaviour
{

    [Header("Check Informations")]
    private GameObject anchor;
    public float CheckDistance;
    public string pickButton;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void CheckForObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit,CheckDistance))
        {
            
        }
    }
}
