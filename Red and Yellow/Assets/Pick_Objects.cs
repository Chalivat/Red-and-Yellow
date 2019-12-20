using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Objects : MonoBehaviour
{

    [Header("Check Informations")]
    public GameObject anchorRight;
    public GameObject anchorLeft;
    public GameObject anchorFront;
    public float CheckDistance;
    public string pickButtonRight;
    public string pickButtonLeft;

    
    public Pickable pickableRight;
    public Pickable pickableLeft;
    public Pickable pickableFront;

    private bool holdingLeft;
    private bool holdingRight;

    void Start()
    {
       
    }
    
    void Update()
    {
        CheckForObject();
        holdObject();
    }

    void holdObject()
    {
        if (!(Input.GetAxis(pickButtonRight) > .1f) && !pickableFront)
        {
            if (pickableRight)
            {
                pickableRight.transform.SetParent(null);
                pickableRight.transform.position = anchorFront.transform.position;
                pickableRight = null;
                holdingRight = false;
            }
        }

        if (!(Input.GetAxis(pickButtonLeft) > .1f) && !pickableFront)
        {
            if (pickableLeft)
            {
                pickableLeft.transform.SetParent(null);
                pickableLeft.transform.position = anchorFront.transform.position;
                pickableLeft = null;
                holdingLeft = false;
            }
        }

        if (!(Input.GetAxis(pickButtonLeft) > .1f) || !(Input.GetAxis(pickButtonRight) >.1f))
        {
            if (pickableFront)
            {
                pickableFront.transform.SetParent(null);
                pickableFront = null;
                holdingLeft = false;
                holdingRight = false;
            }
        }
    }

    void CheckForObject()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position,transform.forward * CheckDistance,Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out hit, CheckDistance))
        {
            if (hit.transform.CompareTag("Pickable") && !pickableFront)
            {


                if (Input.GetAxis(pickButtonRight) > .1f && !holdingRight)
                {
                        pickableRight = hit.transform.GetComponent<Pickable>();
                        if (!pickableRight.isHeld())
                        {
                            pickableRight.Pickup(anchorRight);
                            holdingRight = true;
                        }
                    
                }

                if (Input.GetAxis(pickButtonLeft) > .1f && !holdingLeft)
                {
                        pickableLeft = hit.transform.GetComponent<Pickable>();
                        if (!pickableLeft.isHeld())
                        {
                            pickableLeft.Pickup(anchorLeft);
                            holdingLeft = true;
                        }
                    
                }

            }

            if (hit.transform.CompareTag("Portable"))
            {
                if (Input.GetAxis(pickButtonRight) > .1f && Input.GetAxis(pickButtonLeft) > .1f)
                {
                    if (pickableLeft == null && pickableRight == null)
                    {
                        pickableFront = hit.transform.GetComponent<Pickable>();
                        if (!pickableFront.isHeld())
                        {
                           pickableFront.Pickup(anchorFront);
                           holdingLeft = true;
                           holdingRight = true;
                        }
                    }
                }
            }
        }
    }
}
