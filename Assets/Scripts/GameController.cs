using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public int asteroidCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;
    IEnumerator AsteroidSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                Vector3 spawnLocation = new Vector3(Random.Range(-3, 4), 0, 10);
                Instantiate(asteroid, spawnLocation, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    void Start()
    {
        StartCoroutine(AsteroidSpawner());
    }
}
