using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprisonedMind : MonoBehaviour {


    public bool alienIsImprisoned = false;
    public bool pilotIsImprisoned = true;

    public SpriteRenderer sr;

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


        if (Input.GetAxis("HorizontalKeys" + axisNumber) != 0f || Input.GetAxis("VerticalKeys" + axisNumber) != 0f)
        {
            horDir = Input.GetAxis("HorizontalKeys" + axisNumber);
            verDir = Input.GetAxis("VerticalKeys" + axisNumber);
        }
        else
        {

            horDir = Input.GetAxis("Horizontal" + axisNumber);
            verDir = Input.GetAxis("Vertical" + axisNumber);
        }




    }

    public void fillPossesionMeter()
    {

        

        if(GameLoop.p.horDir != 0 || GameLoop.p.verDir != 0)
        { 
            if(horDir != 0 || verDir != 0)
            {
            Vector2 d = (new Vector2(horDir, verDir) - new Vector2(GameLoop.p.horDir, GameLoop.p.verDir)).normalized;
            GameLoop.changePossesionBar(d.magnitude - 0.5f);

                if ((Mathf.Sign(horDir) != Mathf.Sign(GameLoop.p.horDir) || Mathf.Sign(verDir) != Mathf.Sign(GameLoop.p.verDir)) && d.magnitude > 0.5f)
                {
                    sr.gameObject.SetActive(true);
                }
                else
                    sr.gameObject.SetActive(false);


            }
            else
                sr.gameObject.SetActive(false);
        }
        else
            sr.gameObject.SetActive(false);


    }
}
