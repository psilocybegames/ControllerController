using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunEvent : Event {

    public float damageCounter = 0f;
    public float damageTime = Config.sunDamageTime;


    public override void processEvent()
    {
        base.processEvent();

        if (damageCounter > damageTime)
        {
            GameLoop.damageShipByASun();
            damageCounter = 0f;

        }
        else
            damageCounter += Time.deltaTime;



    }

    public override void onEndEvent()
    {
        base.onEndEvent();
        EventObjects.sun.Stop();
    }

    public override void onFireEvent()
    {
        base.onFireEvent();
        EventObjects.sun.Play();
    }
}
