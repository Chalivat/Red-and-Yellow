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
        Debug.Log(player1.transform.childCount);
        if(player1.transform.Find("RightHand").transform.childCount >= 1 && player1.transform.Find("LeftHand").transform.childCount >= 1 && player2.transform.Find("LeftHand").transform.childCount >= 1 && player1.transform.Find("RightHand").transform.childCount >= 1)
        {
            SceneManager.LoadScene("Example_Cinemachine");
        }
        
    }
}
