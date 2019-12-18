using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Comportement : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Vector3 offset;
    public GameObject[] shootPoint;
    public GameObject[] lazerpoint;
    public GameObject shot;
    public float fireRate;

    public GameObject lazerClimax;
    public GameObject lazerIntro;
    public float lazerTime;

    Transform target;
    float time = 0;
    int vie = 2000;
    bool isLazering = false;

    void Start()
    {
        lazerClimax.SetActive(false);
        lazerIntro.SetActive(false);
        target = player1.transform;
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
    
    void Update()
    {
        if (isLazering)
        {
            Lazering();
        }
        else
        {
            Move();
            Shoot();
        }

        if(vie <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position = new Vector3(transform.position.x, 
            Mathf.SmoothStep(transform.position.y, target.transform.position.y, 0.1f),transform.position.z) + offset ;

        if(vie == 1800 || vie == 1400 || vie == 1000 || vie == 800 || vie == 600 || vie == 400 || vie == 200)
        {
            target = player2.transform;
        }

        if (vie == 1600 || vie == 1200 || vie == 900 || vie == 700 || vie == 500 || vie == 300 || vie == 100)
        {
            target = player1.transform;
        }

        if( vie == 1500)
        {
            isLazering = true;
        }
        
    }
    private void Shoot()
    {
        time += Time.deltaTime;
        
        if(time >= fireRate)
        {
            time = 0;
            Instantiate(shot, shootPoint[Random.Range(0, shootPoint.Length)].transform.position, Quaternion.LookRotation(-transform.forward));
        }
        if (vie == 1000)
        {
            fireRate = fireRate * (1 + 30 / 100);
        }
    }

    void Lazering()
    {
        lazerIntro.SetActive(true);
        time += Time.deltaTime;
        target = lazerpoint[Random.Range(0, lazerpoint.Length)].transform;
        transform.position = new Vector3(transform.position.x,
            Mathf.SmoothStep(transform.position.y, target.transform.position.y, 0.1f), transform.position.z);

        if (time >= 1)
        {
            lazerTime -= Time.deltaTime;
            if(lazerTime > 0)
            {
                lazerClimax.SetActive(true);
            }
            else
            {
                lazerClimax.SetActive(false);
                lazerIntro.SetActive(false);
                time = 0;
                lazerTime = 0;
                target = player1.transform;
                isLazering = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("GoodShot"))
        {
            vie -= 1;
            Destroy(other.gameObject);
        }
    }
}
