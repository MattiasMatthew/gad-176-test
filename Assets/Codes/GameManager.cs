using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance of the GameManager
    public static GameManager Instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure that only one instance of the GameManager exists
        if (Instance == null)
        {
            Instance = this;
            // Optional: Uncomment the next line to keep the GameManager across scenes
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to handle game over state
    public void GameOver()
    {
        // Find the MainCharacter object in the scene
        MainCharacter mainCharacter = FindObjectOfType<MainCharacter>();

        // If the MainCharacter is found, trigger its GameOver method
        if (mainCharacter != null)
        {
            mainCharacter.GameOver();
        }

        // Freeze the game by setting the time scale to 0
        Time.timeScale = 0f;
    }
}
