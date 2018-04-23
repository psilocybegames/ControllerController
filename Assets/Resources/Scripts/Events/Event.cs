using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event {


    public float startTime = 0f;
    public float endTime = 0f;
    public float duration = 15f;
    public float elapsed = 0f;
    public float severity = 1f;
    public bool ended = false;

    // Always use base() in events
    public virtual void processEvent()
    {
        if (elapsed == 0f)
            onFireEvent();

        if(elapsed > duration /2f)
        {
            onHalfDuration();

        }

        if (elapsed > duration && !ended)
            onEndEvent();
        else
            elapsed += Time.deltaTime;

    }

    public virtual void onHalfDuration()
    {
        
    }

    public virtual void initEvent(float sTime)
    {

        startTime = sTime;
        endTime = sTime + duration;

    }

    public virtual void onFireEvent()
    {



    }


    public virtual void onEndEvent()
    {
        ended = true;



    }



      
}


