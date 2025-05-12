using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] obstaclePrefabs;
    public PlayerController playerController; 

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 2f, 3f);             
    }

    void Spawn()
    {
        if (playerController != null && playerController.isGameOver == false)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[index], spawnPoint.position, Quaternion.identity);
        }
    }
}

