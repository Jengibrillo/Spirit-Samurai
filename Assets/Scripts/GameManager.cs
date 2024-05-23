using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText; // Referencia al texto de "You are dead"
    public Button restartButton; // Referencia al bot�n de reinicio

    void Start()
    {
        // Aseg�rate de que la pantalla de Game Over est� desactivada al inicio
        gameOverText.SetActive(false);
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartLevel);
    }

    public void GameOver()
    {
        // Activa la pantalla de Game Over
        gameOverText.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    void RestartLevel()
    {
        // Reinicia el nivel actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
