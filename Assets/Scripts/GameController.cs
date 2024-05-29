using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject enemyShip;
    public GameObject healBall;
    public int enemyWaveTime;
    public int enemyCount;
    public int asteroidCount;
    public float startWait;
    public float spawnWaitAsteroid;
    public float spawnWaitEnemy;
    public float waveWait;
    public Text scoreTxt;
    public static int score;
    
    
    void Start()
    {
        score = 0;
        StartCoroutine(AsteroidSpawner());
    }

    IEnumerator AsteroidSpawner()
    {
        yield return new WaitForSeconds(startWait);
        bool isHealthBallSpawned = false;
        while (true)
        {
            if (Random.value < 0.1f && !isHealthBallSpawned)
            {
                isHealthBallSpawned = true;
                Vector3 spawnLocation = new Vector3(Random.Range(-3, 4), 0, 10);
                Instantiate(healBall, spawnLocation, Quaternion.identity);
            } else
            {
                isHealthBallSpawned = false;
                if (enemyWaveTime != 2)
                {
                    for (int i = 0; i < asteroidCount; i++)
                    {
                        Vector3 spawnLocation = new Vector3(Random.Range(-3, 4), 0, 10);
                        Instantiate(asteroid, spawnLocation, Quaternion.identity);
                        yield return new WaitForSeconds(spawnWaitAsteroid);
                    }
                    yield return new WaitForSeconds(waveWait);
                    enemyWaveTime++;
                } 
                else
                {
                    for (int i = 0; i < enemyCount; i++)
                    {
                        Vector3 spawnLocation = new Vector3(Random.Range(-3, 4), 0, 10);
                        Instantiate(enemyShip, spawnLocation, Quaternion.identity);
                        yield return new WaitForSeconds(spawnWaitEnemy);
                    }
                    enemyWaveTime = 0;
                }
            }
        }
    }

    public void UpdateScore(int point)
    {
        score += point;
        scoreTxt.text = "Score : " + score;
    }
}
