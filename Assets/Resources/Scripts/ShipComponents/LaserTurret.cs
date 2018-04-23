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
        Messages.showSubText(UnityHelper.ColorText("Laser turret engaged!", Color.green));


    }


    public override void onComponentDeactivation()
    {
        base.onComponentDeactivation();
        GameLoop.ship.laserTurretFiring = false;
        Beam.SetActive(false);

    }


}
