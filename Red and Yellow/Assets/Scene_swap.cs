using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_swap : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene("Boss Scene 1");
        }
    }
}
