using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenClear : PowerUp
{
    public override void ApplyPowerUp()
    {
        GameObject[] hazards = GameObject.FindGameObjectsWithTag("Hazard");
        foreach (GameObject hazard in hazards)
        {
            Destroy(hazard);
        }
    }
}
