using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : PowerUp
{

    public override void ApplyPowerUp()
    {
        ScoreCounter.instance.scorePerSecond *= 2;
    }

    public override void RemovePowerUp()
    {
        ScoreCounter.instance.scorePerSecond /= 2;
    }
}
