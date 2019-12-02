using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private bool held;
    private GameObject anchor;
    void Start()
    {
        
    }
    
    void Update()
    {

    }

    void Pickup(GameObject newAnchor)
    {
        anchor = newAnchor;
        transform.SetParent(anchor.transform);
    }

    public bool isHeld()
    {
        return held;
    }
}
