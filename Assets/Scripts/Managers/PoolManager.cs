using Assets.Scripts.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] PoolController _poolController;

        void OnEnable()
        {
            PoolSignals.Instance.onSetEntityToPool += _poolController.OnSetEntityToPool;            
            PoolSignals.Instance.onGetEntityFromPool += _poolController.OnGetEntityFromPool;
        }
        void OnDisable()
        {
            PoolSignals.Instance.onSetEntityToPool -= _poolController.OnSetEntityToPool;
            PoolSignals.Instance.onGetEntityFromPool -= _poolController.OnGetEntityFromPool;
        }
    }
}