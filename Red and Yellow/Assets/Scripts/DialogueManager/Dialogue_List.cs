using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_List : MonoBehaviour
{
    public Transform playerTransform;
    public string[] dialogue;
    public Text playerText;
    
    int count = -2;

    private void OnEnable()
    {
        count += 1;
    }

    void Update()
    {
        transform.position = playerTransform.position;
        Display();
    }

    void Display()
    {
        playerText.text = dialogue[count];
    }
}
