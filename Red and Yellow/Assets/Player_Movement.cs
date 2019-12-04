using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class Player_Movement : MonoBehaviour
{
    public bool isTopView;
    public float speed;
    public float maxSpeed;
    private Rigidbody rb;
    public Camera cam;
    public float groundCheckDistance;

    [Header("Inputs")]
    public string horizontal;
    public string vertical;
    public string lookHor;
    public string lookVer;
    

    private Vector3 lastDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
    }

    void FixedUpdate()
    {
            Move();
            //StayOverGround();
    }

    void Move()
    {
        float x = Input.GetAxis(horizontal);
        float z = 0;
        if (isTopView)
        {
            z = -Input.GetAxis(vertical);
        }
        float a = Input.GetAxisRaw(lookHor);
        float b = Input.GetAxisRaw(lookVer);

        //Vector3 preAim = new Vector3(a,b).normalized;
        //Vector3 aim = AlignInput(a, -b);
        //transform.rotation = Quaternion.LookRotation(aim);
        Vector3 aim = rb.velocity;
        if (new Vector3(a,0,b).magnitude <.3f)
        {
            if (rb.velocity.magnitude > .25f)
            {
                transform.rotation = Quaternion.LookRotation(rb.velocity);
                lastDirection = rb.velocity;
            }
            else transform.rotation = Quaternion.LookRotation(lastDirection);
        }

        Vector3 direction = AlignInput(x, z);
        //direction = new Vector3(direction.x,rb.velocity.y,direction.z);
        //rb.AddForce(direction * speed, ForceMode.VelocityChange);
        SetSpeed(direction);

        
    }

    private void SetSpeed(Vector3 setDirection)
    {
        Vector3 nextSpeed;
        nextSpeed = setDirection;

        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(nextSpeed * speed,ForceMode.VelocityChange);
        }

    }
    void StayOverGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down,out hit,groundCheckDistance))
        {
            if (hit.transform.CompareTag("Ground"))
            {
                if (rb.velocity.y < 0)
                {
                    rb.velocity += Vector3.up * -rb.velocity.y;
                }
            }
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
}
