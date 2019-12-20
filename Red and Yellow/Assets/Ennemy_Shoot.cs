﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering.UI;

public class Ennemy_Shoot : MonoBehaviour
{
    public bool isSideView;

    public GameObject RightWeapon;
    public GameObject LeftWeapon;

    private Weapon rightWeapon, leftWeapon;

    public GameObject Target;
    public GameObject player1, player2;

    public float min, max;
    private float nextShoot;
    private float time;
    public bool canShoot;

    public float maxShootDistance;

    void Start()
    {
        rightWeapon = RightWeapon.GetComponent<Weapon>();
        leftWeapon = LeftWeapon.GetComponent<Weapon>();
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
    }
    
    void Update()
    {
        
        chooseTarget();
        if (Vector3.Distance(transform.position,Target.transform.position) <= maxShootDistance)
        {
            Aim();
            Shoot();
            DecideShoot();
        }
        
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
        if (!isSideView)
        {
            nextRot.z = 0;
            nextRot.x = 0;
        }
        newRot = Quaternion.Euler(nextRot);
        transform.rotation = newRot;
    }

    void DecideShoot()
    {
        if (checkWall())
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

    bool checkWall()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Target.transform.position - transform.position,out hit, Mathf.Infinity))
        {
            Debug.Log(hit);
            Debug.DrawRay(transform.position, hit.point - transform.position, Color.magenta);
            if (hit.transform.CompareTag("Player") || hit.transform.CompareTag("Grille"))
            {
                return true;
            }
            else return false;
        }
        else return false;

        
    }

    void chooseTarget()
    {
        
        float distance1, distance2;

        distance1 = Vector3.Distance(transform.position, player1.transform.position);
        distance2 = Vector3.Distance(transform.position, player2.transform.position);

        if (distance1 >= distance2)
        {
            Target = player2;
        }
        else Target = player1;

        //if (distance1 >= distance2)
        //{
        //    if (player2.activeSelf)
        //    {
        //        Target = player2;
        //    }
        //    else if (player1.activeSelf)
        //    {
        //        Target = player1;
        //    }

        //}
        //else
        //{
        //    if (player1.activeSelf)
        //    {
        //        Target = player1;
        //    }
        //    else if (player2.activeSelf)
        //    {
        //        Target = player2;
        //    }

    }

    }

    

