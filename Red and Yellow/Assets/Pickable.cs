using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private bool held;
    public GameObject anchor;

    public bool reverse;
    void Start()
    {
        
    }
    
    void Update()
    {

    }

    public void Pickup(GameObject newAnchor)
    {
        anchor = newAnchor;
        transform.SetParent(anchor.transform);
        transform.localPosition = Vector3.zero;
        transform.rotation = anchor.transform.rotation;

        if (reverse)
        {
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
    }

    public bool isHeld()
    {
        return held;
    }
}
