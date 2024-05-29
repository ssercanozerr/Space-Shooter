using UnityEngine;

public class HealBallController : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] float _increaseHealthAmount;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.velocity = transform.forward * _speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerShip"))
        {
            other.gameObject.GetComponent<PlayerHealthController>().IncreaseHealth(_increaseHealthAmount);
            Destroy(gameObject);
        }
    }
}
