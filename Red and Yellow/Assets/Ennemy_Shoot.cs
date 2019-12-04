using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Shoot : MonoBehaviour
{
    public GameObject RightWeapon;
    public GameObject LeftWeapon;

    private Weapon rightWeapon, leftWeapon;

    public GameObject Target;
    void Start()
    {
        rightWeapon = RightWeapon.GetComponent<Weapon>();
        leftWeapon = LeftWeapon.GetComponent<Weapon>();
    }
    
    void Update()
    {
        Aim();
        Shoot();
    }

    void Shoot()
    {
        if (rightWeapon)
        {
            rightWeapon.Shoot();
        }

        if (leftWeapon)
        {
            leftWeapon.Shoot();
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

    
}
