using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Weapon : MonoBehaviour
{
    [Header("Main informations")]
    public GameObject Shot;

    public GameObject goodShot;
    public float ShotRate;

    private float time;
    private float preTime;

    public GameObject muzleFlash;

    void Update()
    {
        if (time == preTime)
        {
            muzleFlash.SetActive(false);   
        }

        preTime = time;
    }
    public void Shoot()
    {
        muzleFlash.SetActive(true);
        time += Time.deltaTime;
        if (time >= ShotRate)
        {
            if (transform.parent.CompareTag("Player")) 
            {
                Instantiate(goodShot, transform.position, Quaternion.LookRotation(transform.forward));
            }
            else Instantiate(Shot, transform.position, Quaternion.LookRotation(transform.forward));

            time = 0;
        }
    }

    public void SimpleShoot()
    {
        Instantiate(Shot, transform.position, Quaternion.LookRotation(transform.forward));
    }
}
