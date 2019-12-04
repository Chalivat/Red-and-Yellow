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
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !(Input.GetAxis(JumpInput) < -.5f))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void DoJump()
    {
        if (Input.GetAxis(JumpInput) < -.8f && !wantedToJump)
        {
            wantedToJump = true;
            Debug.Log("LOLOLO");
            rb.AddForce(Vector3.up * JumpStrength);
        }

        if (wantedToJump && Input.GetAxis(JumpInput) >-.8f)
        {
            wantedToJump = false;
        }
    }

    void OnDisable()
    {
        rb.useGravity = false;
    }
}
