using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float speed = 1f;    // Speed of movement
    private bool isGameOver = false;    // Flag to indicate if game is over

    // Update is called once per frame
    private void Update()
    {
        // If game over, stop movement
        if (isGameOver)
            return;

        // Get input from arrow keys or WASD and calculate movement
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Move the character based on input
        transform.Translate(horizontal, vertical, 0f);
    }

    // Method to handle game over state
    public void GameOver()
    {
        isGameOver = true;    // Set game over flag to true
        Debug.Log("Game Over!");    // Log game over to console
    }
}
