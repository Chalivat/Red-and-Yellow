using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System : MonoBehaviour
{

    public float Health;
    private float maxHealth;
    void Start()
    {
        maxHealth = Health;
    }
    
    void Update()
    {
        
    }

    public void Heal(int life)
    {
        Health += maxHealth;
        if (Health >= maxHealth)
        {
            Health = maxHealth;
        }
    }

    public void Damage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Death();
        }
    }

    void Death()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shot"))
        {
            Damage(other.transform.gameObject.GetComponent<shot_Behavior>().damage);
            Debug.Break();
        }
    }



}

