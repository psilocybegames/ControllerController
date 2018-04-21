using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {


    public static PilotController p;
    public static float shipHealth = 10f;
    public static float maxShipHealth = 10f;
    public static float travelTime = Config.travelTime;
    public static float possesionMeter = 0f;
    public static float maxPossesion = 10f;

    public Bar healthBar;
    public Bar possesionBar;

    public void switchControls()
    {



    }

    void Start()
    {



    }
	void Awake ()
    {
        p = GameObject.Find("ThePilot").GetComponent<PilotController>();
        healthBar = GameObject.Find("ShipHealthBar").GetComponent<Bar>();
        possesionBar = GameObject.Find("PossesionBar").GetComponent<Bar>();
        Config.initControlScheme();

    }
    
	
	void Update ()
    {
        healthBar.percentFilled = shipHealth / maxShipHealth;
        possesionBar.percentFilled = possesionMeter / maxPossesion;
        possesionMeter += Config.constantPossesionChange;

        if(possesionMeter > maxPossesion)
        {
            switchPossesion();


        }
		
	}

    public void switchPossesion()
    {
        
    }

    public static void changePossesionBar(float d)
    {
        possesionMeter += d * Config.movementPossesionChange;
        


    }
}
