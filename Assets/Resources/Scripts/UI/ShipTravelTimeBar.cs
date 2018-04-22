using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTravelTimeBar : MonoBehaviour {


    public SpriteRenderer shipSymbol;
    public SpriteRenderer travelLine;
    float travelLineWidth = 0f;
	
	void Awake ()
    {
        shipSymbol = transform.Find("Symbol").GetComponent<SpriteRenderer>();
        travelLine = GetComponent<SpriteRenderer>();
        travelLineWidth = travelLine.bounds.size.x * travelLine.transform.localScale.x;
	}

    
	
	
	void Update () {

        setTravelTimeSymbolLocation();	
	}

    public void setTravelTimeSymbolLocation()
    {
        float percent = GameLoop.currentTravelTime / GameLoop.travelTime;
        shipSymbol.transform.localPosition = new Vector3(-travelLineWidth + travelLineWidth * percent, 0f, 0f);
        
    }
}
