using UnityEngine;

public class MoveLeftByPlayer : MonoBehaviour
{
    public PlayerController playerController;

    void Update()
    {
        if (!GameManager.Instance.player1.IsGameOver() && !GameManager.Instance.player2.IsGameOver())
        {
            float baseSpeed = GameManager.Instance.gameSpeed;
            float boost = playerController != null ? playerController.speedOffset : 0f;
            transform.Translate(Vector3.left * (baseSpeed + boost) * Time.deltaTime);
        }
    }
}