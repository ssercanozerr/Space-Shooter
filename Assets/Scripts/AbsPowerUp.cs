using UnityEngine;

public abstract class AbsPowerUp : MonoBehaviour
{
    public float speed;
    protected Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    public virtual void UsePowerUp()
    {
        Destroy(gameObject);
    }

}
