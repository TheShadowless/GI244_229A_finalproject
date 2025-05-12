using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        if (!GameManager.Instance.IsGameOver())
        {
            transform.Translate(Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime);
        }
    }
}
