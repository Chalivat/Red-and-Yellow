using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_Behavior : MonoBehaviour
{
    public float Speed;
    private Rigidbody rb;

    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Speed;
    }
    
}
