using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    private PlayerController playerController;

    private void Start()
    {
        var go = GameObject.Find("Player1");
        playerController = go.GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!GameManager.Instance.player1.IsGameOver() && !GameManager.Instance.player2.IsGameOver())
        {
            transform.Translate(Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime);
        }
    }

}
