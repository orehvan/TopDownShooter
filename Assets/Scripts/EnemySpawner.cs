using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning = false;
    
    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), spawnTime, spawnDelay);
    }

    void SpawnObject()
    {
        var randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        Instantiate(enemy, randomSpawnPoint, transform.rotation);

        if (stopSpawning)
            CancelInvoke(nameof(SpawnObject));
    }
}
