using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInMiddle : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = PositionBetween(Player1, Player2);
    }

    Vector3 PositionBetween(GameObject a, GameObject b)
    {
        Vector3 posA, posB;
        posA = a.transform.position;
        posB = b.transform.position;

        return Vector3.Lerp(posA,posB,.5f);
    }
}
