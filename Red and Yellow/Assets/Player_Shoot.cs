using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    [Header("Main Shoot informations")]
    public GameObject Shot;
    public float shotRate;
    public Camera cam;
    public float RotateSpeed;

    public GameObject RightWeapon;
    public GameObject LeftWeapon;

    private Weapon rightWeapon,leftWeapon;

    [Header("Inputs")]
    public string lookHor;
    public string lookVer;

    private Pick_Objects pickObjects;
    private Player_Movement playerMovement;

    

    void Start()
    {
        pickObjects = GetComponent<Pick_Objects>();
        playerMovement = GetComponent<Player_Movement>();
        cam = playerMovement.cam;
    }
    
    void Update()
    {
        GetWeapons();
        Shoot();
    }

    void Shoot()
    {
        float x = Input.GetAxis(lookHor);
        float z = Input.GetAxis(lookVer);
        
        Vector3 aim = AlignInput(x, -z);
        if (aim.magnitude > .25f)
        {
            if (playerMovement.isTopView)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(AlignInput(x, -z)), RotateSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 bis = AlignInputSide(x, -z);
                Debug.Log(bis);
                //transform.rotation = Quaternion.LookRotation(new Vector3(z,x,0));
                Quaternion newRot = cam.gameObject.transform.rotation;
                Vector3 nextRot = newRot.eulerAngles;
                nextRot.y = 0;
                nextRot.x = 0;
                newRot = Quaternion.Euler(nextRot);
                Vector3 newLook = newRot * bis;
                transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(newLook), RotateSpeed * Time.deltaTime);
            }

            if (RightWeapon && rightWeapon)
            {
                rightWeapon.Shoot();
            }

            if (LeftWeapon && leftWeapon)
            {
                leftWeapon.Shoot();
            }
        }
        

        //RightWeapon.shoot
        //LeftWeapon.shoot
    }


    void GetWeapons()
    {
        if (pickObjects.pickableLeft)
        {
            LeftWeapon = pickObjects.pickableLeft.gameObject;
            leftWeapon = LeftWeapon.GetComponent<Weapon>();
        }
        else
        {
            LeftWeapon = null;
            leftWeapon = null;
        }

        if (pickObjects.pickableRight)
        {
            RightWeapon = pickObjects.pickableRight.gameObject;
            rightWeapon = RightWeapon.GetComponent<Weapon>();
        }
        else
        {
            RightWeapon = null;
            rightWeapon = null;
        }

    }


    Vector3 AlignInput(float x, float y)
    {
        Vector3 direction = new Vector3(x, 0, y);
        Vector3 bis = direction;
        Quaternion newRot = Quaternion.LookRotation(cam.transform.forward);
        Vector3 nextRot = newRot.eulerAngles;
        nextRot.x = 0;
        nextRot.z = 0;
        newRot = Quaternion.Euler(nextRot);
        direction = newRot * direction;

        return direction;
    }

    Vector3 AlignInputSide(float x, float y)
    {
        Vector3 direction = new Vector3(0, y, x);
        Vector3 bis = direction;
        Quaternion newRot = Quaternion.LookRotation(cam.transform.forward);
        Vector3 nextRot = newRot.eulerAngles;
        nextRot.x = 0;
        nextRot.y = 0;
        newRot = Quaternion.Euler(nextRot);
        direction = newRot * direction;

        return direction;
    }
}
