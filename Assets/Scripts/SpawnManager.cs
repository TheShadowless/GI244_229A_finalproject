using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject speedBoostItemPrefab;
    public GameObject shieldItemPrefab;
    [Range(0f, 1f)] public float speedBoostChance = 0.1f;
    [Range(0f, 1f)] public float shieldChance = 0.1f;

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
        if (playerController != null && !playerController.isGameOver)
        {
            GameObject objToSpawn = null;

            float rand = Random.Range(0f, 1f);

            if (rand < healSpawnChance && healItemPrefab != null)
            {
                objToSpawn = healItemPrefab;
            }
            else if (rand < healSpawnChance + speedBoostChance && speedBoostItemPrefab != null)
            {
                objToSpawn = speedBoostItemPrefab;
            }
            else if (obstaclePrefabs.Length > 0)
            {
                int index = Random.Range(0, obstaclePrefabs.Length);
                objToSpawn = obstaclePrefabs[index];
            }

            if (objToSpawn != null)
            {
                GameObject spawned = Instantiate(objToSpawn, spawnPoint.position, Quaternion.identity);                               
                MoveLeft move = spawned.GetComponent<MoveLeft>();
                if (move != null)
                {
                    move.playerController = this.playerController;
                }
            }
        }
    }

}

