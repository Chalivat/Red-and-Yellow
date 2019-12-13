using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public Animator heartAnimator;
    public float Life1, Life2;
    public Image imageLife1, imageLife2;
    void Start()
    {
        imageLife1.fillAmount = 1;
        imageLife2.fillAmount = 2;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HeartBeat();
        }
        UpdateLife();
    }

    public void DamagePlayer1(int playerNumber,float damage)
    {
        HeartBeat();
        if (playerNumber == 1)
        {
            Life1 -= damage;
        }
        else if (playerNumber == 2)
        {
            Life2 -= damage;
        }
    }

    void UpdateLife()
    {
        imageLife1.fillAmount = Mathf.Lerp(imageLife1.fillAmount, Life1, 5f * Time.deltaTime);
        imageLife2.fillAmount = Mathf.Lerp(imageLife2.fillAmount, Life2, 5f * Time.deltaTime);
    }

    
    public void HeartBeat()
    {
        heartAnimator.Play("HeartBeat");
    }
}
