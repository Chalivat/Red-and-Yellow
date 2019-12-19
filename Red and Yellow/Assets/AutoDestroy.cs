using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        Invoke("Death",3);
    }
    

    void Death()
    {
        Destroy(gameObject);
    }
}
