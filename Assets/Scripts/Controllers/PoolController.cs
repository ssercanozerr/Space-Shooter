using Assets.Scripts.Enums;
using Assets.Scripts.Managers;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class PoolController : MonoBehaviour
    {
        [SerializeField] PoolInfos _poolInfos;

        Dictionary<EntityTypes, PoolInfo> _pools;

        void Awake()
        {
            _pools = new Dictionary<EntityTypes, PoolInfo>();

            for (int i = 0; i < _poolInfos.poolInfos.Count; i++)
            {
                PoolInfo poolInfo = _poolInfos.poolInfos[i];
                _pools.Add(poolInfo.entityType, poolInfo);

                FillThePool(poolInfo, poolInfo.startSize);
            }
        }

        public GameObject OnGetEntityFromPool(EntityTypes entityType)
        {
            PoolInfo poolInfo = _pools[entityType];
            if (poolInfo.poolQueue.Count == 0)
            {
                FillThePool(poolInfo, poolInfo.increaseAmount);
            }
            GameObject takenEntity = poolInfo.poolQueue.Dequeue();
            takenEntity.SetActive(true);
            return takenEntity;
        }
        public void OnSetEntityToPool(EntityTypes entityType, GameObject gameObject)
        {
            PoolInfo poolInfo = _pools[entityType];
            SetObjectToPool(gameObject, poolInfo);
        }

        private static void SetObjectToPool(GameObject gameObject, PoolInfo poolInfo)
        {
            gameObject.SetActive(false);
            poolInfo.poolQueue.Enqueue(gameObject);
        }

        private static void FillThePool(PoolInfo poolInfo, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject newEntity = Instantiate(poolInfo.entityPrefab, Vector3.down * 10, Quaternion.identity);
                SetObjectToPool(newEntity, poolInfo);
            }
        }

    }
}