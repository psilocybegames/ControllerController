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
        
    }

   
    public override void onComponentDeactivation()
    {
        base.onComponentDeactivation();
        GameLoop.ship.laserTurretFiring = false;
        Beam.SetActive(false);

    }


}
