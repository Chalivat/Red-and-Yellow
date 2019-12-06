using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private bool held;
    public GameObject anchor;
    public GameObject circle;
    public bool reverse;
    void Start()
    {
        circle.SetActive(true);
    }
    
    void Update()
    {
        if (transform.parent)
        {
            circle.SetActive(false);
        }
        else circle.SetActive(true);
    }

    public void Pickup(GameObject newAnchor)
    {
        anchor = newAnchor;
        transform.SetParent(anchor.transform);
        transform.localPosition = Vector3.zero;
        transform.rotation = anchor.transform.rotation;
        circle.SetActive(false);
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
