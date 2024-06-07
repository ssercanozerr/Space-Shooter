using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidsController : MonoBehaviour
{
    Rigidbody rb;
    public float rotationSpeed;
    public float speed;
    public GameObject explosionAsteroid;
    public GameObject explosionPlayer;
    public GameObject explosionEnemy;

    GameController gameController;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        rb.velocity = transform.forward * speed;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bolt"))
        {
            Instantiate(explosionAsteroid, transform.position, transform.rotation);
            gameController.UpdateScore(10);
            PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.PlayerBolt, other.gameObject);
            PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.Asteroid, gameObject);
        }
        if (other.gameObject.tag == "PlayerShip")
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            PlayerSignals.Instance.onResetBulletPowerUp?.Invoke();
            PlayerSignals.Instance.onDecreasePlayerHealth?.Invoke(10);
            PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.Asteroid, gameObject);
        }
        if (other.gameObject.tag == "EnemyShip")
        {
            Instantiate(explosionEnemy, other.transform.position, other.transform.rotation);
            gameController.UpdateScore(20);
            PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.EnemyShip, other.gameObject);
            PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.Asteroid, gameObject);
        }
    }
}
