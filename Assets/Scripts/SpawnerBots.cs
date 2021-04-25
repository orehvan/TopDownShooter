using System.Collections;
using UnityEngine;

public class SpawnerBots : MonoBehaviour
{ 
    public Transform spawnPos;
    public GameObject square;
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
        Instantiate(square, spawnPos.position, Quaternion.identity);
        Repeat();
    }
}
