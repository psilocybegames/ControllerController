using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesEvent : Event {

    public float damageCounter = 0f;
    public float damageTime = Config.MinesDamageTime;

    public override void processEvent()
    {
        base.processEvent();
        if (damageCounter > damageTime)
        {
            GameLoop.damageShipByAMine();
            damageCounter = 0f;

        }
        else
            damageCounter += Time.deltaTime;



    }

    public override void onEndEvent()
    {
        base.onEndEvent();
        EventObjects.mines.Stop();
    }

    public override void onHalfDuration()
    {
        base.onHalfDuration();
        EventObjects.mines.Stop();

    }



    public override void onFireEvent()
    {
        Messages.showMessage(UnityHelper.ColorText("Mines!", Color.white));
        Messages.showSubText(UnityHelper.ColorText("Use helm to navigate safely!",Color.green));

        base.onFireEvent();
        SoundManager manager = GameLoop.getSoundManager();
        manager.PlaySingle(manager.Shield_colission_mine);
        EventObjects.mines.Play();
    }
}
