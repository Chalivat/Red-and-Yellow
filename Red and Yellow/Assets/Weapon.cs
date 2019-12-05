using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Main informations")]
    public GameObject Shot;
    public float ShotRate;

    private float time;
    

    public void Shoot()
    {
        time += Time.deltaTime;
        if (time >= ShotRate)
        {
            Instantiate(Shot, transform.position, Quaternion.LookRotation(transform.forward));
            time = 0;
        }
    }

    public void SimpleShoot()
    {
        Instantiate(Shot, transform.position, Quaternion.LookRotation(transform.forward));
    }
}
