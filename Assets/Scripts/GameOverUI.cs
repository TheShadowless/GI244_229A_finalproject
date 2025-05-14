using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text winnerText;

    public void ShowWinner(string winner)
    {
        winnerText.text = winner;
        gameOverPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}

