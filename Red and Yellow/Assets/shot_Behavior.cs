﻿using System.Collections;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            Debug.Log(other);
            Destroy(gameObject);
        }

        if (other.GetComponent<Collider>().CompareTag("Wall"))
        {
            //Debug.Break();
            Debug.Log("hey");
            Destroy(gameObject);
        }
    }




}
