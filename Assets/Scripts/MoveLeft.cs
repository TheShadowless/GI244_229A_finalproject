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
            float boost = playerController != null ? playerController.speedOffset : 0f;
            transform.Translate(Vector3.left * (speed + boost) * Time.deltaTime);
        }
    }
}
