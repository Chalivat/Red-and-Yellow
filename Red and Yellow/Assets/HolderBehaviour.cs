using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderBehaviour : MonoBehaviour
{
    
    public GameObject holderSpawned;
    private Pick_Objects pickObjects;

    void Start()
    {
        holderSpawned = new GameObject("outHolder");
        holderSpawned.transform.position = transform.position;
        holderSpawned.transform.rotation = transform.rotation;
        transform.root.GetComponent<Pick_Objects>().anchorFront = holderSpawned;
    }

    void Update()
    {
        holderSpawned.transform.position = transform.position;
        holderSpawned.transform.rotation = transform.rotation;
    }
}
