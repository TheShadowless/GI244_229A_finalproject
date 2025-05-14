using TMPro;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    public PlayerController player;
    public TMP_Text hpText;

    public Transform playerPos;             
    public TMP_Text distanceText;        
    
    public float speed = 10f; 
    private float elapsedTime;

    
    void Update()
    {
        if (player != null)
        {
            hpText.text = "HP: " + player.currentHP.ToString();
            if (player.isGameOver == false)
            {
                elapsedTime += Time.deltaTime;
                float distance = elapsedTime * GameManager.Instance.gameSpeed;
                distanceText.text = "Distance: " + Mathf.FloorToInt(distance) + " m";
            }
        }
    }
}
