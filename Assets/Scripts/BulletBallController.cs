using Assets.Scripts.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBallController : AbsPowerUp
{
    public override void UsePowerUp()
    {
        PlayerSignals.Instance.onIncreaseBulletPowerUp?.Invoke(); 
        base.UsePowerUp();
    }
}
