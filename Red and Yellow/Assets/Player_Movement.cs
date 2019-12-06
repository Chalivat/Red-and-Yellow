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

    [Header("Inputs")] public string horizontal;
    public string vertical;
    public string lookHor;
    public string lookVer;


    private Vector3 lastDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (isTopView)
        {
            GetComponent<Jump>().enabled = false;
        }
        else GetComponent<Jump>().enabled = true;
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        Move();
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
        if (new Vector3(a, 0, b).magnitude < .3f)
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
        Vector3 applySpeed;
        applySpeed = Vector3.zero;
        nextSpeed = setDirection;
        Vector3 newMagnitude;
        newMagnitude = rb.velocity;
        newMagnitude.y = 0;
        if (isTopView)
        {

            rb.AddForce(nextSpeed * speed, ForceMode.VelocityChange);

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }

            rb.velocity = rb.velocity * Mathf.Lerp(.5f,1,nextSpeed.magnitude);
        }
    

    else

    {
        if (newMagnitude.z < maxSpeed && nextSpeed.x > 0)
        {
            rb.AddForce(nextSpeed * speed, ForceMode.VelocityChange);
        }
        else if (newMagnitude.z > -maxSpeed && nextSpeed.x < 0)
        {
            rb.AddForce(nextSpeed * speed, ForceMode.VelocityChange);
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
