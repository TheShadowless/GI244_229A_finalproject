using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public PlayerController playerController;

    void Update()
    {
        if (playerController != null && !playerController.IsGameOver())
        {
            float baseSpeed = GameManager.Instance.gameSpeed;
            float boost = playerController.speedOffset;
            transform.Translate(Vector3.left * (baseSpeed + boost) * Time.deltaTime);
        }
    }
}
