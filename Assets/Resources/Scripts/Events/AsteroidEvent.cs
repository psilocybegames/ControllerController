using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEvent : Event {


    public float damageCounter = 0f;
    public float damageTime = Config.AsteroidDamageTime;

    public override void processEvent()
    {
        base.processEvent();
        if (damageCounter > damageTime)
        {
            GameLoop.damageShipByAsteroid();
            damageCounter = 0f;

        }
        else
            damageCounter += Time.deltaTime;



    }

    public override void onEndEvent()
    {
        base.onEndEvent();
        EventObjects.asteroids.Stop();
    }

    public override void onFireEvent()
    {
        base.onFireEvent();
        EventObjects.asteroids.Play();
    }
}
