using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    public GameObject cible;
    public GameObject cam;
    public GameObject vCam;
    public bool isCam = false;
    public Vector3 inheritRotation;

    GameObject player;
    bool isTriggered = false;
    int count = 0;

    private void Update()
    {
        Debug.Log(count);

        if (isTriggered)
        {
            count += 1;

            if(count == 1)
            {
                player.GetComponent<Player_Movement>().isTopView = !player.GetComponent<Player_Movement>().isTopView;
                player.GetComponent<Player_Movement>().enabled = false;
                player.GetComponent<Player_Shoot>().enabled = false;
            }
            if(count == 2)
            {
                player.transform.position = cible.transform.position;
                player.transform.rotation = Quaternion.LookRotation(inheritRotation);
                isCam = !isCam;

                if (player.GetComponent<Player_Movement>().isTopView)
                {
                    player.GetComponent<Player_Movement>().cam = vCam;
                    player.GetComponent<Player_Shoot>().cam = vCam;
                }
                else
                {
                    player.GetComponent<Player_Movement>().cam = cam;
                    player.GetComponent<Player_Shoot>().cam = cam;
                }
                CameraSpawner();
            }
            if(count == 3)
            {
                player.GetComponent<Player_Movement>().enabled = true;
                player.GetComponent<Player_Shoot>().enabled = true;
                player.GetComponent<Jump>().enabled = true;
            }
            if(count == 4)
            {
                isTriggered = false;
                count = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            isTriggered = true;
        }
    }

    void CameraSpawner()
    {
        if (isCam)
        {
            cam.SetActive(true);
            vCam.SetActive(false);
        }
        else
        {
            cam.SetActive(false);
            vCam.SetActive(true);
        }
    }
}
