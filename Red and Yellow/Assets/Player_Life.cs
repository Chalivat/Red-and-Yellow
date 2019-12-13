using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life : MonoBehaviour
{
    public TimeManagement timeManagement;
    public UI_Manager uiManager;
    public int playerNumber;
    public float Health;
    public GameObject Pouf;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        timeManagement.FreezeTime(20);
        uiManager.DamagePlayer1(playerNumber,12/100f);
        Health -= damage;
        if (Health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Instantiate(Pouf, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shot"))
        {
            Damage(other.transform.gameObject.GetComponent<shot_Behavior>().damage);
        }
    }
}
