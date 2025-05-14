using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameSpeed = 10f;
    public float speedIncreaseRate = 0.2f;
    public float maxSpeed = 25f;
    public PlayerController player1;
    public PlayerController player2;

    public GameOverUI gameOverUI; 
    private bool hasShownResult = false; 

    void Awake()
    {
        
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        var go1 = GameObject.Find("Player1");
        if (go1 != null) player1 = go1.GetComponent<PlayerController>();

        var go2 = GameObject.Find("Player2");
        if (go2 != null) player2 = go2.GetComponent<PlayerController>();
    }

    void Update()
    {
        if ((!player1.isGameOver || !player2.isGameOver) && gameSpeed < maxSpeed)
        {
            gameSpeed += speedIncreaseRate * Time.deltaTime;
        }

        PlayerWin();


    }
    public void PlayerWin()
    {
        if (player1 == null || player2 == null || hasShownResult) return;

        if (player1.isGameOver && !player2.isGameOver)
        {
            gameOverUI.ShowWinner("Player 2 wins!");
            hasShownResult = true;
        }
        else if (player2.isGameOver && !player1.isGameOver)
        {
            gameOverUI.ShowWinner("Player 1 wins!");
            hasShownResult = true;
        }
        else if (player1.isGameOver && player2.isGameOver)
        {
            gameOverUI.ShowWinner("Draw!");
            hasShownResult = true;
        }
    }

}
