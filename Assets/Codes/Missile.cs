using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform target;    // Target to follow (MainCharacter)
    public float speed = 5f;    // Speed of the missile
    public float rotateSpeed = 200f;    // Rotation speed of the missile
    public GameObject Kaboom;    // Explosion prefab

    private Rigidbody2D rb;    // Rigidbody component of the missile

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    // Get the Rigidbody component on start
    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        // Calculate direction to the target
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();    // Normalize direction vector

        // Calculate rotation amount
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;    // Apply rotation speed

        // Move the missile towards the target
        rb.velocity = transform.up * speed;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);    // Log collision

        // Check if the collided object is tagged as "Player" (MainCharacter)
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit the player!");
            Instantiate(Kaboom, transform.position, transform.rotation);    // Instantiate explosion
            Destroy(gameObject);    // Destroy the missile object
            GameManager.Instance.GameOver();    // Trigger game over in the GameManager
        }
    }
}
