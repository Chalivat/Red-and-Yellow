using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene1_Condition : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(player1.transform.childCount >= 6 || player2.transform.childCount >= 6)
        {
            SceneManager.LoadScene("Example_Cinemachine");
        }
        
    }
}
