using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float maxPlayerHP = 5;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public float spawnX = -7.87f;
    public float spawnY = -0.71f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public string playerFireButton = "Player1Fire";
    public string playerJumpButton = "Jump";
    public string playerHorizontalMovement = "Horizontal";
    public string playerPickupButton = "Player1Pickup";
    public GameObject objectHeld;
    private bool currentlyHolding = false;


    void Update()
    {
        if(PauseManager.isPaused)
        {
            return;
        }

        horizontal = Input.GetAxisRaw(playerHorizontalMovement);

        if (Input.GetButtonDown(playerJumpButton) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp(playerJumpButton) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (objectHeld == null)
        {
            currentlyHolding = false;
        }

        
        Flip();
    }

    private void FixedUpdate()
    {
        if (PauseManager.isPaused)
        {
            return;
        }

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
        if (Input.GetAxis(playerPickupButton) != 0 && !currentlyHolding)
        {
            if(collision.tag == "Pickupable" && collision.GetComponent<SpawnerScript>().thingCurrentlySpawned != null)
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
        if (collision.tag == "Death Floor")
        {
                gameObject.SetActive(false);
        }
    }

    public void takeDamage(int amount)
    {
        maxPlayerHP -= amount;
        if(maxPlayerHP <= 0)
        {
            MangerScript.numPlayersAlive--;
            Debug.Log(gameObject.ToString());
            gameObject.SetActive(false);
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (!IsGrounded() && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 5f);
        }
    }
}