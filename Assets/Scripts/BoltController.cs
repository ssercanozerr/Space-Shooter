using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoltController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] bool _isPlayer;
    public GameObject explosionPlayer;
    public GameObject explosionEnemy;
    public GameObject explosionBolt;
    public GameController gameController;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        gameController = GameObject.FindWithTag("GameManager").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bolt")
        {
            Instantiate(explosionBolt, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.UpdateScore(5);
        }
        if (other.gameObject.tag == "EnemyShip")
        {
            Instantiate(explosionEnemy, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.UpdateScore(20);
        }
        if (other.gameObject.tag == "PlayerShip")
        {
            if (_isPlayer) return;
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
            Destroy(gameObject);
            other.gameObject.GetComponent<PlayerHealthController>().DecreaseHealth(20);
            //SceneManager.LoadScene(2);
        }
    }
}
