using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;

    [SerializeField] float nextFire;
    [SerializeField] float fireRate;

    public float moveSpeed;

    public GameObject shot;
    public GameObject shotSpawnLeft;
    public GameObject shotSpawnRight;
    public GameObject explosionPlayer;
    public GameObject explosionEnemy;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("PlayerShip");
        if (playerObject)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            SpawnEnemyBolt(shotSpawnLeft.transform.position, shotSpawnLeft.transform.rotation);
            SpawnEnemyBolt(shotSpawnRight.transform.position, shotSpawnRight.transform.rotation);
        }
    }

    private void SpawnEnemyBolt(Vector3 vector, Quaternion quaternion)
    {
        GameObject newEnemyBolt = PoolSignals.Instance.onGetEntityFromPool.Invoke(EntityTypes.EnemyBolt);
        newEnemyBolt.transform.position = vector;
        newEnemyBolt.transform.rotation = Quaternion.Euler(quaternion.eulerAngles);
        newEnemyBolt.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerShip")
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            Instantiate(explosionEnemy, transform.position, transform.rotation);
            PlayerSignals.Instance.onDecreasePlayerHealth?.Invoke(50);
            PlayerSignals.Instance.onResetBulletPowerUp?.Invoke();
            PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.EnemyShip, gameObject);
        }
    }
}
