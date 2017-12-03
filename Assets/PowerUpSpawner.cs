using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

    public Transform[] spawnPoints;

    public GameObject powerUp;

    public float despawnTime;
    public float spawnTime;

    private void Start()
    {
        spawnTime = 30f;
        despawnTime = 15f;

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Destroy(Instantiate(powerUp, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity), despawnTime);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(Spawn());
    }
}
