using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform[] SpawnPoints;

    public GameObject EnemyPrefab;

    public float SpawnTime;

    private void Start()
    {
        SpawnTime = 5f;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(SpawnTime);
        Instantiate(EnemyPrefab, SpawnPoints[Random.Range(0, SpawnPoints.Length)]);
        StartCoroutine(SpawnEnemy());
    }
}
