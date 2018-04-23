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

    public override void onHalfDuration()
    {
        base.onHalfDuration();
        EventObjects.asteroids.Stop();

    }

    public override void onEndEvent()
    {
        base.onEndEvent();
        if (Messages.t.text == UnityHelper.ColorText("Asteroids!", Color.white))
            Messages.t.text = "";

        if (Messages.st.text == UnityHelper.ColorText("Shoot them with lasers!", Color.green))
            Messages.st.text = "";
    }

    public override void onFireEvent()
    {
        base.onFireEvent();
        Messages.showMessage(UnityHelper.ColorText("Asteroids!", Color.white));
        Messages.showSubText(UnityHelper.ColorText("Shoot them with lasers!", Color.green));
        EventObjects.asteroids.Play();
    }
}
