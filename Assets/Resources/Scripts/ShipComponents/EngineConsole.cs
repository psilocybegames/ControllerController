using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineConsole : ShipComponent {


    public override void shipComponentActivated()
    {
        base.shipComponentActivated();
        GameLoop.ship.enginesTuned = true;
        GameLoop.ship.shipSpeed = Config.shipSpeedFast;
        Messages.showSubText(Messages.st.text + UnityHelper.ColorText("\nTravel speed increased!", Color.cyan));

        EventObjects.setAllParticleSystemSpeed();
    }

    
    public override void onComponentDeactivation()
    {
        base.onComponentDeactivation();
        GameLoop.ship.enginesTuned = false;
        GameLoop.ship.shipSpeed = Config.shipSpeedNormal;
        EventObjects.setAllParticleSystemSpeed();
    }

}
