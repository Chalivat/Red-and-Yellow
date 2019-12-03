using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Objects : MonoBehaviour
{

    [Header("Check Informations")]
    public GameObject anchorRight;
    public GameObject anchorLeft;
    public float CheckDistance;
    public string pickButtonRight;
    public string pickButtonLeft;

    
    public Pickable pickableRight;
    public Pickable pickableLeft;

    private bool holdingLeft;
    private bool holdingRight;

    void Start()
    {
        
    }
    
    void Update()
    {
        Debug.Log("Gauche : " + pickableLeft + " Droite : " + pickableRight);
        Debug.Log( holdingLeft + " : " + holdingRight);
        CheckForObject();
        holdObject();
    }

    void holdObject()
    {
        if (!(Input.GetAxis(pickButtonRight) > .1f))
        {
            if (pickableRight)
            {
                pickableRight.transform.SetParent(null);
                pickableRight = null;
                holdingRight = false;
            }
        }

        if (!(Input.GetAxis(pickButtonLeft) > .1f))
        {
            if (pickableLeft)
            {
                pickableLeft.transform.SetParent(null);
                pickableLeft = null;
                holdingLeft = false;
            }
        }
    }

    void CheckForObject()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position,transform.forward * CheckDistance,Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out hit, CheckDistance))
        {
            if (hit.transform.CompareTag("Pickable"))
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
        }
    }
}
