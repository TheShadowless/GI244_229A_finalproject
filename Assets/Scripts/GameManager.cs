using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameSpeed = 10f;
    public float speedIncreaseRate = 0.2f;
    public float maxSpeed = 25f;

    private PlayerController playerController;

    void Awake()
    {
        //check GameManager ตัวเดียว
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        var go = GameObject.Find("Player");
        playerController = go.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.isGameOver && gameSpeed < maxSpeed)
        {
            gameSpeed += speedIncreaseRate * Time.deltaTime;
        }
    }
}
