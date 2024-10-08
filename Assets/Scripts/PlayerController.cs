﻿using UnityEngine;

[System.Serializable]
public class Baundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public Baundary baundary;

    
    [SerializeField] float speed;
    [SerializeField] float tilt;


    Rigidbody rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;

        Vector3 position = new Vector3(
            Mathf.Clamp(rb.position.x, baundary.xMin, baundary.xMax),
            0,
            Mathf.Clamp(rb.position.z, baundary.zMin, baundary.zMax));
        rb.position = position;

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * tilt);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AbsPowerUp powerUp))
        {
            powerUp.UsePowerUp();
        }
    }
}