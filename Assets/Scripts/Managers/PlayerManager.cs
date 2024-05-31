using Assets.Scripts.Controllers;
using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] PlayerHealthController _playerHealthController;
        [SerializeField] PlayerFireController _playerFireController;

        void OnEnable()
        {
            PlayerSignals.Instance.onIncreasePlayerHealth += _playerHealthController.IncreaseHealth;
            PlayerSignals.Instance.onDecreasePlayerHealth += _playerHealthController.DecreaseHealth;
            PlayerSignals.Instance.onIncreaseBulletPowerUp += _playerFireController.OnIncreasePowerUpLevel;
            PlayerSignals.Instance.onResetBulletPowerUp += _playerFireController.OnResetPowerUpLevel;
        }
        void OnDisable()
        {
            PlayerSignals.Instance.onIncreasePlayerHealth -= _playerHealthController.IncreaseHealth;
            PlayerSignals.Instance.onDecreasePlayerHealth -= _playerHealthController.DecreaseHealth;
            PlayerSignals.Instance.onIncreaseBulletPowerUp -= _playerFireController.OnIncreasePowerUpLevel;
            PlayerSignals.Instance.onResetBulletPowerUp -= _playerFireController.OnResetPowerUpLevel;
        }
    }
}