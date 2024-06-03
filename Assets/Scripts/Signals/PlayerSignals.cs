using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class PlayerSignals : MonoBehaviour
    {
        public static PlayerSignals Instance;

        public UnityAction<float> onIncreasePlayerHealth;
        public UnityAction<float> onDecreasePlayerHealth;
        public UnityAction onIncreaseBulletPowerUp;
        public UnityAction onResetBulletPowerUp;
        public Func<bool> onIsBulletLevelMax;

        void Awake()
        {
            Instance = this;
        }
    }
}