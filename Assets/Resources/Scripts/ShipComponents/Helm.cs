using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helm : ShipComponent
{

    public GameObject Beam;

    Vector3 originalBeamScale;



    public override void shipComponentActivated()
    {
        base.shipComponentActivated();
        GameLoop.ship.helmEngaged = true;
        EventObjects.startSwayingVertically();
        if (GameLoop.gl.currentEvent != null)
        {
            if (GameLoop.gl.currentEvent.GetType() == typeof(MinesEvent))
                Messages.showSubText(UnityHelper.ColorText("Laser turret engaged!", Color.green));
        }



    }


    public override void onComponentDeactivation()
    {
        base.onComponentDeactivation();
        GameLoop.ship.helmEngaged = false;
        EventObjects.stopSwayingVertically();

    }


}
