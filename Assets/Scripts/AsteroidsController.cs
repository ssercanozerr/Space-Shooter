﻿using System.Collections;
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
    public GameController gameController;
    void Start()
    {
        gameController = GameObject.FindWithTag("GameManager").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        rb.velocity = transform.forward * speed;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bolt")
        {
            Instantiate(explosionAsteroid, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.UpdateScore();
        }
        if(other.gameObject.tag == "PlayerShip")
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
