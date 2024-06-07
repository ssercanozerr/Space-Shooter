using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class EnemyBoltController : AbsBolt
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bolt"))
            {
                Instantiate(explosionBolt, other.transform.position, other.transform.rotation);
                gameController.UpdateScore(5);

                if (other.TryGetComponent(out PlayerBoltController playerBoltController))
                {
                    PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.PlayerBolt, other.gameObject);
                    PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.EnemyBolt, gameObject);
                }
                else
                {
                    PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.EnemyBolt, other.gameObject);
                    PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.EnemyBolt, gameObject);
                }
                
            }
            if (other.gameObject.tag == "PlayerShip")
            {
                Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
                PlayerSignals.Instance.onResetBulletPowerUp?.Invoke();
                PlayerSignals.Instance.onDecreasePlayerHealth?.Invoke(20);
                PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.EnemyBolt, gameObject);
            }
            base.OnTriggerEnter(other);
        }
    }
}