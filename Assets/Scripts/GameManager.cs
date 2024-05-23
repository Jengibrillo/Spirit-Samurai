using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText; // Reference to "You are dead" text
    public Button restartButton; // Reference to the restart button

    void Start()
    {
        // Ensure the Game Over screen is deactivated at the start
        gameOverText.SetActive(false);
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartLevel);
    }

    public void GameOver()
    {
        // Activate the Game Over screen
        gameOverText.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    void RestartLevel()
    {
        // Restart the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
