using Assets.Scripts.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject enemyShip;
    public GameObject healBall;
    public GameObject bulletBall;
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
        StartCoroutine(ObjectSpawner());
    }

    IEnumerator ObjectSpawner()
    {
        yield return new WaitForSeconds(startWait);
        bool isHealthBallSpawned = false;
        bool isBulletBallSpawned = false;
        while (true)
        {
            if (Random.value < 0.3f && !isHealthBallSpawned && !(bool)PlayerSignals.Instance.onIsHealthBarMax?.Invoke())
            {
                isHealthBallSpawned = true;
                Vector3 spawnLocation = new Vector3(Random.Range(-3, 4), 0, 10);
                Instantiate(healBall, spawnLocation, Quaternion.identity);
            }
            else if (Random.value < 0.4f && !isBulletBallSpawned && !(bool)PlayerSignals.Instance.onIsBulletLevelMax?.Invoke() && score >= 200)
            {
                isBulletBallSpawned = true;
                Vector3 spawnLocation = new Vector3(Random.Range(-3, 4), 0, 10);
                Instantiate(bulletBall, spawnLocation, Quaternion.identity);
            }
            else
            {
                isHealthBallSpawned = false;
                isBulletBallSpawned = false;
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
                    asteroidCount++;
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
                    enemyCount++;
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
