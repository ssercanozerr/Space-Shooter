using Assets.Scripts.Signals;
using UnityEngine;

public class HealBallController : AbsPowerUp
{
    [SerializeField] float _increaseHealthAmount;

    public override void UsePowerUp()
    {
        PlayerSignals.Instance.onIncreasePlayerHealth?.Invoke(_increaseHealthAmount);
        base.UsePowerUp();
    }
}
