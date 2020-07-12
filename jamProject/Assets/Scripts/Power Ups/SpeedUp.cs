using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerUp
{
    public float movmentSpeed;
    public float torqueSpeed;
    public float maxVelocity;
    public float maxAngularVelocity;
    public float modifier = 1.0F;

    private Player player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void ApplyPowerUp()
    {
        Apply(modifier);
    }

    public override void RemovePowerUp()
    {
        Apply(-modifier);
    }

    public void Apply(float modifier)
    {
        player.movmentSpeed += movmentSpeed * modifier;
        player.torqueSpeed += torqueSpeed * modifier;
        player.maxVelocity += maxVelocity * modifier;
        player.maxAngularVelocity += maxAngularVelocity * modifier;
    }
}
