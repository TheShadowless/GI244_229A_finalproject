using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text winnerText;

    public void ShowWinner(string message)
    {
        Time.timeScale = 0f; 
        gameOverPanel.SetActive(true);
        winnerText.text = message;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

