using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public int asteroidCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;
    public Text scoreTxt;
    public static int score;
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

    public void UpdateScore()
    {
        score += 10;
        scoreTxt.text = "Score : " + score;
    }

    void Start()
    {
        score = 0;
        StartCoroutine(AsteroidSpawner());
    }
}
