using Assets.Scripts.Enums;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class PoolSignals : MonoBehaviour
    {
        public static PoolSignals Instance;

        public Func<EntityTypes, GameObject> onGetEntityFromPool;
        public UnityAction<EntityTypes, GameObject> onSetEntityToPool;

        void Awake()
        {
            Instance = this;
        }
    }
}