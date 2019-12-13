using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Health_System : MonoBehaviour
{

    public float Health;
    private float maxHealth;

    public bool isPlayer;
    
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
        if (Health <= 0 && !isPlayer)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoodShot"))
        {
            Damage(other.transform.gameObject.GetComponent<shot_Behavior>().damage);
        }
    }



}

