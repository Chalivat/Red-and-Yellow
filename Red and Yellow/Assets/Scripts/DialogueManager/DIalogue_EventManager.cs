using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogue_EventManager : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panelTuto;
    int count = 0;

    public bool isis = false;
    bool isTutoOver = false;
    bool isSecance1Over = false;

    bool isSecance2Over = true;

    void Start()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panelTuto.SetActive(false);
    }
    
    void Update()
    {
        Debug.Log(count);
        SecanceOne();
        if (!isSecance2Over)
        {
            secanceTwo();
        }
    }

    void SecanceOne()
    {
        if (count == 10)
        {
            panelTuto.SetActive(true);
            Time.timeScale = 0.01f;
            if (Input.GetButtonDown("Fire1"))
            {
                panelTuto.SetActive(false);
                Debug.Log("Ta mere");
                isTutoOver = true;
                Time.timeScale = 1;
                isSecance1Over = true;
                count += 1;
            }
            panel1.SetActive(false);
            panel2.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1") && !isSecance1Over)
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
            count += 1;
        }
    }

    void secanceTwo()
    {
        
    }
}
