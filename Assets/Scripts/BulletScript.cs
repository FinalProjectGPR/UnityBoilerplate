using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    public float aliveTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(Mathf.Cos(transform.localEulerAngles.z * Mathf.Deg2Rad) * speed, Mathf.Sin(transform.localEulerAngles.z * Mathf.Deg2Rad) * speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= Time.deltaTime;
        if(aliveTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
    }
}
