using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject[] obstaclePrefabs;
    public GameObject healItemPrefab;
    [Range(0f, 1f)] public float healSpawnChance = 0.2f;
    [Range(0.5f, 1.5f)] public float randTimeSpawn;
    public PlayerController playerController;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), randTimeSpawn, 3f);
    }

    void Spawn()
    {
        if (playerController != null && playerController.isGameOver == false)
        {
            float rand = Random.Range(0f, 1f);

            if (rand < healSpawnChance && healItemPrefab != null)
            {                
                Instantiate(healItemPrefab, spawnPoint.position, Quaternion.identity);
            }
            else if (obstaclePrefabs.Length > 0)
            {                
                int index = Random.Range(0, obstaclePrefabs.Length);
                Instantiate(obstaclePrefabs[index], spawnPoint.position, Quaternion.identity);
            }
        }
    }
}

