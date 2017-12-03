using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

    public Transform[] spawnPoints;

    public GameObject powerUp;
    public GameObject immortalPowerUp;

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
        switch(Random.Range(0, 10))
        {
            case 0:
                Destroy(Instantiate(immortalPowerUp, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity), despawnTime);
                break;
            default:
                Destroy(Instantiate(powerUp, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity), despawnTime);
                break;
        }

        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(Spawn());
    }
}
