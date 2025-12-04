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
    public Vector3 startingCoords = new Vector3(-6f, 5.5f, -2.2f);
    public bool selectedIsTrigger = false;
    public string selectorChooseButton = "Jump";
    public string selectorHorizontalAxis = "Horizontal";
    public string selectorVerticalAxis = "Vertical";
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis(selectorHorizontalAxis)*speed, Input.GetAxis(selectorVerticalAxis)*speed);
        if (Input.GetButtonDown(selectorChooseButton) && hasSelected && MangerScript.isPlacing==true)
        {
            gameObject.SetActive(false);
            if(Physics2D.OverlapBox(selectedObject.transform.position, selectedObject.transform.localScale, 0f) == null)
            {
                selectedObject.transform.SetParent(null, true);
                selectedObject.transform.position = selectedObject.transform.position - new Vector3(0f, 0f, selectedObject.transform.position.z - .1f);
                selectedObject.GetComponent<Collider2D>().isTrigger = selectedIsTrigger;
                selectedObject = null;
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis(selectorChooseButton) != 0 && !hasSelected && collision.gameObject.transform.position.z == -2.1f)
        {
            spawner.GetComponent<StuffSpawnerScript>().stuffSpawned[Array.IndexOf(spawner.GetComponent<StuffSpawnerScript>().stuffSpawned, collision.gameObject)] = null;
            selectedObject = collision.gameObject;
            selectedObject.transform.SetParent(gameObject.transform, false);
            selectedObject.transform.localPosition = new Vector3(-.5f + (selectedObject.transform.localScale.x/2), .5f - (selectedObject.transform.localScale.y/2), 0);
            selectedIsTrigger = selectedObject.GetComponent<Collider2D>().isTrigger;
            selectedObject.SetActive(false);
            gameObject.SetActive(false);
            hasSelected = true;
        }
    }
}
