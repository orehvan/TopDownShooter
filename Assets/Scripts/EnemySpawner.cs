using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnTime;
    public float spawnDelay;
    private int stopSpawning;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), spawnTime, spawnDelay);
        stopSpawning++;
    }

    void SpawnObject()
    {
        var randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        var enemy = Instantiate(enemyPrefab, randomSpawnPoint, transform.rotation);

        enemy.GetComponent<AIDestinationSetter>().target = player.transform;
        // AIDestinationSetter.target = player.transform;

        if (stopSpawning >= 3)
            while (true)
            {
                CancelInvoke(nameof(Start));

                
    }
}
