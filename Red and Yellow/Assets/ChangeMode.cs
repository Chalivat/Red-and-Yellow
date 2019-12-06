using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    public GameObject cible;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player_Movement>().isTopView = !other.GetComponent<Player_Movement>().isTopView;
            other.transform.position = cible.transform.position;
        }
    }
}
