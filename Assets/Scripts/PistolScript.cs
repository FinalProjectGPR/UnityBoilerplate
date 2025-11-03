using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    string currentFireButton = "";
    public GameObject firePoint;
    public GameObject bullet;
    public float fireRate;
    public float bulletSpeed;
    public float aliveTime;
    public float numBullets;
    public float bulletSpread;
    // Start is called before the first frame update
    void Start()
    {
        currentFireButton = "Player1Fire";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(currentFireButton) != 0)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
