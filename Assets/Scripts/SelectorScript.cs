using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SelectorScript : MonoBehaviour
{
    public GameObject selectedObject;
    public bool hasSelected;
    public bool isPlacing;
    public Rigidbody2D rb;
    public float speed = 3f;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed);
        if (Input.GetButtonDown("Jump") && hasSelected && MangerScript.isPlacing==true)
        {
            selectedObject.transform.SetParent(null, true);
            selectedObject.transform.position = selectedObject.transform.position - new Vector3(0f, 0f, selectedObject.transform.position.z - .1f);
            selectedObject = null;
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis("Jump") != 0 && !hasSelected && collision.gameObject.transform.position.z == -2.1f)
        {
            spawner.GetComponent<StuffSpawnerScript>().stuffSpawned[Array.IndexOf(spawner.GetComponent<StuffSpawnerScript>().stuffSpawned, collision.gameObject)] = null;
            selectedObject = collision.gameObject;
            selectedObject.transform.SetParent(gameObject.transform, false);
            selectedObject.transform.localPosition = new Vector3(-.5f + (selectedObject.transform.localScale.x/2), .5f - (selectedObject.transform.localScale.y/2), 0);
            selectedObject.SetActive(false);
            gameObject.SetActive(false);
            hasSelected = true;
        }
    }
}
