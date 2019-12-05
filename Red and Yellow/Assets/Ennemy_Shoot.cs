using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Shoot : MonoBehaviour
{
    public GameObject RightWeapon;
    public GameObject LeftWeapon;

    private Weapon rightWeapon, leftWeapon;

    public GameObject Target;

    public float min, max;
    private float nextShoot;
    private float time;
    private bool canShoot;

    void Start()
    {
        rightWeapon = RightWeapon.GetComponent<Weapon>();
        leftWeapon = LeftWeapon.GetComponent<Weapon>();
    }
    
    void Update()
    {
        Aim();
        Shoot();
        DecideShoot();
    }

    void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            if (rightWeapon)
            {
                rightWeapon.SimpleShoot();
            }

            if (leftWeapon)
            {
                leftWeapon.SimpleShoot();
            }
        }
    }

    void Aim()
    {
        Quaternion newRot = Quaternion.LookRotation(Target.transform.position - transform.position);
        Vector3 nextRot = newRot.eulerAngles;
        nextRot.z = 0;
        nextRot.x = 0;
        newRot = Quaternion.Euler(nextRot);
        transform.rotation = newRot;
    }

    void DecideShoot()
    {
        time += Time.deltaTime;
        if (time >= nextShoot)
        {
            time = 0;
            nextShoot = Random.Range(min, max);
            canShoot = true;
        }
    }

    
}
