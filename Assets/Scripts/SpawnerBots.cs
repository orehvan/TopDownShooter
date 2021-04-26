using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnerBots : MonoBehaviour
{ 
    public Transform spawnPos;
    public GameObject bots;
    public float timeSpawn;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Repeat()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeSpawn);
        Instantiate(bots, spawnPos.position, Quaternion.identity);
        Repeat();
    }
}
