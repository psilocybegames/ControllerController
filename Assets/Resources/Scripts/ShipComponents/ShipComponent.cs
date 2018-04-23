using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : InteractableObject
{
    private PilotController pilot;
    public UsableItem.ItemType itemNeeded;
    public float activationDuration = 10f;
    public float activationCounter = 0f;


    public bool activated = false;


    public virtual void shipComponentActivated()
    {
        activated = true;
    }

    public override void onCursorClick(int button)
    {

        if (pilot.heldItem != null && !pilot.clickedThisFrame && !activated)
        {
            if (pilot.heldItem.type == itemNeeded)
            {
                shipComponentActivated();
            }
            else
            {
                if(pilot.heldItem.type == UsableItem.ItemType.ArcWelder)
                {
                    if (pilot.controlledByAlien)
                    { 
                        GameLoop.repairShip();
                        
                    }
                    else
                    {
                        GameLoop.damageShipByArcWelder();

                    }

                    pilot.dropHeldItem();

                }
                    else
                { }
                GameLoop.wrongItemUsedOnStation();

            }
        }


    }


    public virtual void Update()
    {
        if (activated)
        {
            processActivatedAnimation();

            if (activationCounter > activationDuration)
            {
                activationCounter = 0f;
                activated = false;
                onComponentDeactivation();
            }
            else
                activationCounter += Time.deltaTime;
        }


    }

    public virtual void onComponentDeactivation()
    {

    }

    public virtual void processActivatedAnimation()
    {

        transform.localScale = Vector3.one + Vector3.one * Mathf.Sin(Time.time * 10f) * 0.03f;

    }

    public virtual void Start()
    {
        pilot = FindObjectOfType<PilotController>();
    }

}
