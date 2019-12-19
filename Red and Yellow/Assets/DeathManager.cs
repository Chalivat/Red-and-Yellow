using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{

    public GameObject Player1, Player2;
    private GameObject[] Players;

    public Player_Life life1, life2;

    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        Player1 = GameObject.Find("Player 1");
        Player2 = GameObject.Find("Player 2");

        life1 = Player1.GetComponent<Player_Life>();
        life2 = Player2.GetComponent<Player_Life>();
    }
    
    void Update()
    {
        if (life1.Health <= 0)
        {
            Debug.Log("Player 1 dead");
            Invoke("Respawn1",5f);
        }

        if (life2.Health <= 0)
        {
            Invoke("Respawn2", 5f);
            Debug.Log("Player 2 dead");
        }
    }

    void Respawn1()
    {
        Player1.SetActive(true);
        life1.Health = 100;
        life1.uiManager.Life1 = 100;
        life1.uiManager.imageLife1.fillAmount = 1;
    }

    void Respawn2()
    {
        Player2.SetActive(true);
        life2.Health = 100;
        life2.uiManager.Life2 = 100;
        life2.uiManager.imageLife2.fillAmount = 1;
    }
}
