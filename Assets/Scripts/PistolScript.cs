using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    string currentFireButton = "";
    public GameObject firePoint;
    public GameObject bullet;
    public GameObject currentBullet;

    public float bulletSpeed;
    public float aliveTime;
    public float numBullets;
    public float bulletSpread;

    public float timeOut = 1f;
    public float timeRemaining;
    public bool canFire;

    // Start is called before the first frame update
    void Start()
    {
        currentFireButton = "Player1Fire";
    }

    // Update is called once per frame
    void Update()
    {
        if(currentFireButton != "")
        {
            if (Input.GetAxis(currentFireButton) != 0 && canFire)
            {
                if (numBullets == 1)
                {
                    firePoint.transform.localEulerAngles = new Vector3(0, 0, 0);
                    currentBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    currentBullet.GetComponent<BulletScript>().speed = bulletSpeed;
                    currentBullet.GetComponent<BulletScript>().aliveTime = aliveTime;
                }
                else
                {
                    firePoint.transform.localEulerAngles = new Vector3(0, 0, (bulletSpread / 2));
                    for (int i = 0; i < numBullets; i++)
                    {
                        Debug.Log(firePoint.transform.localEulerAngles.z);
                        currentBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                        firePoint.transform.localEulerAngles = new Vector3(0, 0, firePoint.transform.localEulerAngles.z - (bulletSpread / (numBullets - 1)));
                        currentBullet.GetComponent<BulletScript>().speed = bulletSpeed;
                        currentBullet.GetComponent<BulletScript>().aliveTime = aliveTime;
                    }
                }
                canFire = false;
                timeRemaining = timeOut;
            }
        }
        if (!canFire)
        {
            timeRemaining -= Time.deltaTime;
            if(timeRemaining <= 0)
            {
                canFire = true;
            }
        }
    }
}
