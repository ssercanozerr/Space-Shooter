using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AbsBolt : MonoBehaviour
    {
        protected Rigidbody rb;
        [SerializeField] protected float speed;
        public GameObject explosionPlayer;
        public GameObject explosionEnemy;
        public GameObject explosionBolt;

        [HideInInspector]public GameController gameController;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            gameController = GameObject.FindWithTag("GameManager").GetComponent<GameController>();

        }

        void OnDisable()
        {
            rb.velocity = Vector3.zero;
        }
        void OnEnable()
        {
            rb.velocity = transform.forward * speed;
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "EnemyShip")
            {
                Instantiate(explosionEnemy, other.transform.position, other.transform.rotation);
                gameController.UpdateScore(20);
                PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.EnemyShip, other.gameObject);
                PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.PlayerBolt, gameObject);
            }
            
        }
    }
}