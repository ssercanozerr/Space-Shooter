using Assets.Scripts.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            if (other.TryGetComponent(out PlayerBoltController playerBoltController))
            {
                PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.PlayerBolt, other.gameObject);
            }
            else 
            {
                PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.EnemyBolt, other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Asteroid"))
        {
            PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.Asteroid, other.gameObject);
        }
        else if (other.gameObject.CompareTag("EnemyShip"))
        {
            PoolSignals.Instance.onSetEntityToPool.Invoke(EntityTypes.EnemyShip, other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
