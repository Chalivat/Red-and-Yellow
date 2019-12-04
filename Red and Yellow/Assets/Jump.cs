using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public string JumpInput;
    public float JumpStrength;
    private Rigidbody rb;

    public float fallMultiplier;
    public float lowJumpMultiplier;

    private bool wantedToJump;

    public int maxJump;
    private int jumpCount;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        if (rb)
        {
            rb.useGravity = true;
        }
    }
    
    void Update()
    {
        DoJump();
        CheckGround();
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            //rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y + Vector3.up.y * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime,rb.velocity.z);
            //rb.AddForce(Vector3.up * Physics.gravity.y * (fallMultiplier - 1));
        }
        else if (rb.velocity.y > 0 && !(Input.GetAxis(JumpInput) < -.5f))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + Vector3.up.y * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime, rb.velocity.z);
            //rb.AddForce(Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1));
        }
    }

    void DoJump()
    {
        if (Input.GetAxis(JumpInput) < -.8f && !wantedToJump && jumpCount < maxJump)
        {
            wantedToJump = true;
            Debug.Log("LOLOLO");
            rb.AddForce(Vector3.up * JumpStrength);
            jumpCount++;
        }

        if (wantedToJump && Input.GetAxis(JumpInput) >-.8f)
        {
            wantedToJump = false;
        }
    }


    void CheckGround()
    {
        if (Physics.Raycast(transform.position,Vector3.down,1.2f))
        {
            if (!wantedToJump)
            {
                jumpCount = 0;
            }
        }
    }
    void OnDisable()
    {
        rb.useGravity = false;
    }
}
