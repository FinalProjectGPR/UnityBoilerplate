using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorScript : MonoBehaviour
{
    public GameObject selectedObject;
    public bool hasSelected;
    public bool isPlacing;
    public Rigidbody2D rb;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis("Jump") != 0 && !hasSelected)
        {
            selectedObject = collision.gameObject;
            selectedObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
