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
        


        if (Messages.t.text == UnityHelper.ColorText("Too close to the sun!", Color.white))
            Messages.t.text = "";

        if (Messages.st.text == UnityHelper.ColorText("Overcharge the shields!", Color.green))
            Messages.st.text = "";
    }

    public override void onFireEvent()
    {
        Debug.Log("Sun");
        base.onFireEvent();
        SoundManager manager = GameLoop.getSoundManager();
        manager.PlaySingle(manager.Sun_frying);
        Messages.showMessage(UnityHelper.ColorText("Too close to the sun!", Color.white));
        Messages.showSubText(UnityHelper.ColorText("Overcharge the shields!", Color.green));

        EventObjects.sun.Play();
    }
}
