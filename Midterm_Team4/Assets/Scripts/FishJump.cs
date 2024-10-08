using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishJump : MonoBehaviour
{
    public float jumpForceX = 2f;  // Horizontal force for the jump
    public float jumpForceY = 5f;  // Vertical force for the jump
    //public float lifetime = 5f;    // Time to destroy fish after spawning, if needed

    private Rigidbody2D rb;
    private float startX;
    private float startY;          // The starting X position of the fish
    private bool isDescending = false;  // Flag to check if the fish is coming down
    private bool facingLeft = false;
    //private float tolerance = 0.1f;

    //spawn splash
    public GameObject splashVFX;
    //public AudioSource splashSFX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startX = transform.position.x; // Store the starting X position
        startY = transform.position.y;  // Store the starting Y position
        if(startX > 0f)
        {
            facingLeft = true;
        }
        Jump();
        PlayFX();
    }

    void Jump()
    {
        // Apply an arc-like force to the fish
        float randomDirection = Random.Range(1f, 2f);  // Slight variation in horizontal direction
        if (facingLeft)
        {
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
            randomDirection *= -1;
        }
        Vector2 jumpDirection = new Vector2(randomDirection * jumpForceX, jumpForceY);

        rb.velocity = Vector2.zero;  // Reset velocity to ensure clean jump
        rb.AddForce(jumpDirection, ForceMode2D.Impulse);  // Apply jump force
    }

    void Update()
    {

        RotateFishAlongPath();

        // Check if the fish is coming down
        if (rb.velocity.y < 0)
        {
            isDescending = true;  // The fish has passed the peak and is descending
        }


        // Check if the fish has crossed back over the starting X position and is descending
        if (isDescending && (transform.position.y <= startY))
        {
            PlayFX();
            Destroy(gameObject);  // Despawn the fish once it crosses back over its starting point
        }
    }

    void RotateFishAlongPath()
    {
        // Get the velocity of the fish
        Vector2 velocity = rb.velocity;

        // Calculate the angle of the velocity vector
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        //if (facingLeft)
        //{
        //    angle *= -1;
        //}

        // Apply the rotation to the fish's Z axis
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void PlayFX(){
        Instantiate (splashVFX, transform.position, Quaternion.identity);
        //splashSFX.Play();
    }


}
