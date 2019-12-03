using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public bool isTopView;
    public float speed;
    private Rigidbody rb;
    public Camera cam;

    [Header("Inputs")]
    public string horizontal;
    public string vertical;
    public string lookHor;
    public string lookVer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isTopView)
        {
            TopView();
        }
        else SideView();
    }

    void TopView()
    {
        float x = Input.GetAxis(horizontal);
        float z = -Input.GetAxis(vertical);
        float a = Input.GetAxisRaw(lookHor);
        float b = Input.GetAxisRaw(lookVer);

        //Vector3 preAim = new Vector3(a,b).normalized;
        //Vector3 aim = AlignInput(a, -b);
        //transform.rotation = Quaternion.LookRotation(aim);
        Vector3 aim = rb.velocity;
        if (new Vector3(a,0,b).magnitude <.3f)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }

        Vector3 direction = AlignInput(x, z);
        rb.velocity = direction * speed;
    }

    void SideView()
    {

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
}
