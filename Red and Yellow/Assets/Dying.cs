using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour
{

    public AnimationCurve curve;
    private float index;
    private bool isDead;
    void Start()
    {
        isDead = false;
    }
    
    void Update()
    {
        if (isDead)
        {
            GoThroughCurve();
        }
    }

    void GoThroughCurve()
    {

    }

    public void Die()
    {
        isDead = true;
    }
}
