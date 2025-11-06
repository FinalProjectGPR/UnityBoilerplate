using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float maxPlayerHP = 5;
    public float pistolDamage = 1;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public string playerFireButton = "Player1Fire";
    public GameObject objectHeld;
    private bool currentlyHolding = false;


    void Update()
    {
        if(PauseManager.isPaused)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            if(objectHeld != null && objectHeld.GetComponent<GunScript>() != null)
            {
                objectHeld.GetComponent<GunScript>().bulletSpeed *= -1;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis("Player1Pickup") != 0 && !currentlyHolding)
        {
            if(collision.tag == "Pickupable")
            {
                objectHeld = collision.GetComponent<SpawnerScript>().thingCurrentlySpawned;
                collision.GetComponent<SpawnerScript>().thingCurrentlySpawned = null;
                objectHeld.GetComponent<GunScript>().currentFireButton = playerFireButton;
                objectHeld.transform.position = new Vector3(.5f, 0f, 0f);
                objectHeld.transform.SetParent(gameObject.transform, false);
                objectHeld.GetComponent<GunScript>().bulletSpeed *= transform.localScale.x;
                currentlyHolding = true;
            }
        }
        if (collision.tag == "Bullet")
        {
            maxPlayerHP = (maxPlayerHP - pistolDamage);
            
            if (maxPlayerHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}