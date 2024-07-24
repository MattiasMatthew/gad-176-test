using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMissile : Missile
{
    private Camera mainCamera;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    // FixedUpdate is called at a fixed interval
    protected override void FixedUpdate()
    {
        MoveRandomly();
    }

    // Move the missile randomly within the camera view
    private void MoveRandomly()
    {
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        float randomY = Random.Range(-screenBounds.y, screenBounds.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);
        rb.velocity = (randomPosition - rb.position).normalized * speed;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
