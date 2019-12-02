using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogue_EventManager : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public bool isis = false;

    void Start()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isis)
            {
                panel1.SetActive(true);
                panel2.SetActive(false);
            }
            if (!isis)
            {
                panel2.SetActive(true);
                panel1.SetActive(false);
            }
            isis = !isis;
        }
    }
}
