using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    public GameObject cible;
    public GameObject cible2;
    public GameObject cam;
    public GameObject vCam;
    public bool isCam = false;
    public Vector3 inheritRotation;

    GameObject player;
    GameObject player2;
    bool isTriggered = false;
    int count = 0;
    int playerCount = 0;

    private void Start()
    {
        CameraSpawner();
    }
    private void Update()
    {
        if (isTriggered)
        {
            count += 1;

            if(count == 1)
            {
                player.GetComponent<Player_Movement>().isTopView = !player.GetComponent<Player_Movement>().isTopView;
                player.GetComponent<Player_Movement>().enabled = false;
                player.GetComponent<Player_Shoot>().enabled = false;
                player2.GetComponent<Player_Movement>().isTopView = !player2.GetComponent<Player_Movement>().isTopView;
                player2.GetComponent<Player_Movement>().enabled = false;
                player2.GetComponent<Player_Shoot>().enabled = false;
            }
            if(count == 2)
            {
                player.transform.position = cible.transform.position;
                player.transform.rotation = Quaternion.LookRotation(inheritRotation);
                player2.transform.position = cible2.transform.position;
                player2.transform.rotation = Quaternion.LookRotation(inheritRotation);
                isCam = !isCam;

                if (player.GetComponent<Player_Movement>().isTopView)
                {
                    player.GetComponent<Player_Movement>().cam = vCam;
                    player.GetComponent<Player_Shoot>().cam = vCam;
                    player2.GetComponent<Player_Movement>().cam = vCam;
                    player2.GetComponent<Player_Shoot>().cam = vCam;
                }
                else
                {
                    player.GetComponent<Player_Movement>().cam = cam;
                    player.GetComponent<Player_Shoot>().cam = cam;
                    player2.GetComponent<Player_Movement>().cam = cam;
                    player2.GetComponent<Player_Shoot>().cam = cam;
                }
                CameraSpawner();
            }
            if(count == 3)
            {
                player.GetComponent<Player_Movement>().enabled = true;
                player.GetComponent<Player_Shoot>().enabled = true;
                player.GetComponent<Jump>().enabled = true;
                player2.GetComponent<Player_Movement>().enabled = true;
                player2.GetComponent<Player_Shoot>().enabled = true;
                player2.GetComponent<Jump>().enabled = true;
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
            playerCount += 1;
            if(playerCount == 1)
            {
                player = other.gameObject;
            }
            if(playerCount >= 2)
            {
                player2 = other.gameObject;
                isTriggered = true;
                playerCount = 0;
            }
        }
    }

    void CameraSpawner()
    {
        Debug.Log("COUCPU");
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
