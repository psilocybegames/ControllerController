using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCore : ShipComponent
{

    public GameObject shield;

    Vector3 originalShieldScale;

    public override void Start()
    {

        base.Start();
        originalShieldScale = shield.transform.localScale;

    }

    public override void shipComponentActivated()
    {
        base.shipComponentActivated();
        GameLoop.ship.shieldOvercharged = true;
        shield.SetActive(true);
        GetComponent<Animator>().SetBool("ShieldOn", true);
        if (GameLoop.gl.currentEvent != null)
        {
            if (GameLoop.gl.currentEvent.GetType() == typeof(SunEvent))
                Messages.showSubText(UnityHelper.ColorText("Shields Overcharged!", Color.green));
        }


    }

    public override void processActivatedAnimation()
    {
        base.processActivatedAnimation();

        shield.transform.localScale = originalShieldScale + Vector3.one * 0.05f * Mathf.Sin(Time.time * 20f);
    }


    public override void onComponentDeactivation()
    {
        base.onComponentDeactivation();
        GetComponent<Animator>().SetBool("ShieldOn", false);
        
        GameLoop.ship.shieldOvercharged = false;
        shield.SetActive(false);
        shield.transform.localScale = originalShieldScale;


    }

}
