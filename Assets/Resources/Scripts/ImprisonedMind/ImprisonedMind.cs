using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprisonedMind : MonoBehaviour {


    public bool alienIsImprisoned = false;
    public bool pilotIsImprisoned = true;


    public float horDir = 0f;
    public float verDir = 0f;


    void Start ()
    {
		
	}
	
	void Update ()
    {
        checkForMovementAxis();
        fillPossesionMeter();
		
	}

    public void checkForMovementAxis()
    {
        string axisNumber = "2";
        if (GameLoop.p.controlledByAlien)
            axisNumber = "1";

        horDir = Input.GetAxis("Horizontal" + axisNumber);
        verDir = Input.GetAxis("Vertical" + axisNumber);





    }

    public void fillPossesionMeter()
    {

        if(GameLoop.p.horDir != 0 || GameLoop.p.verDir != 0)
        { 
            if(horDir != 0 || verDir != 0)
            {
            Vector2 d = (new Vector2(horDir, verDir) - new Vector2(GameLoop.p.horDir, GameLoop.p.verDir)).normalized;
            GameLoop.changePossesionBar(d.magnitude - 0.5f);
            }
        }


    }
}
