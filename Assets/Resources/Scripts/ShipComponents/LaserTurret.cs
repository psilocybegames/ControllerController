using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : ShipComponent
{

    public GameObject Beam;

    Vector3 originalBeamScale;


   
    public override void shipComponentActivated()
    {
        base.shipComponentActivated();
        GameLoop.ship.laserTurretFiring = true;
        Beam.SetActive(true);
        if(GameLoop.gl.currentEvent != null)
        { 
        if (GameLoop.gl.currentEvent.GetType() == typeof(AsteroidEvent))
            Messages.showSubText(UnityHelper.ColorText("Laser turret engaged!", Color.green));
            SoundManager manager = GameLoop.getSoundManager();
            manager.PlaySingle(manager.laser_zap);
        }


    }


    public override void onComponentDeactivation()
    {
        base.onComponentDeactivation();
        GameLoop.ship.laserTurretFiring = false;
        Beam.SetActive(false);

    }


}
