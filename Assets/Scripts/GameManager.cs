using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameSpeed = 10f;
    public float speedIncreaseRate = 0.2f;
    public float maxSpeed = 25f;
    public PlayerController player1;
    public PlayerController player2;

    private bool gameEnded = false;
    //private PlayerController playerController;

    void Awake()
    {
        //check GameManager ตัวเดียว
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        var go1 = GameObject.Find("Player1");
        player1 = go1.GetComponent<PlayerController>();

        var go2 = GameObject.Find("Player2");
        player2 = go1.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!player1.isGameOver && gameSpeed < maxSpeed && !player2.isGameOver)
        {
            gameSpeed += speedIncreaseRate * Time.deltaTime;
        }

        if (!gameEnded)
        {
            if (player1.isGameOver)
            {
                Debug.Log("🎉 Player 2 wins!");
                gameEnded = true;
            }
            else if (player2.isGameOver)
            {
                Debug.Log("🎉 Player 1 wins!");
                gameEnded = true;
            }
        }
    }
}
