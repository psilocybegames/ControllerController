using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : InteractableObject
{
    public PilotController pilot;
    public ItemType type;

    public enum ItemType
    {
        ControlRod,
        PilotClearance,
        InhibitorReleaseKey,
        EngineerHud,
        ArcWelder
    }

    public override void onCursorClick(int button)
    {
        if(!pilot.clickedThisFrame)
        {
            pilot.clickedThisFrame = true;
            pilot.pickUpItem(this);
        }
    }


    public bool UseItemOn(ShipComponent component)
    {
        return false;
    }

    public virtual void Start()
    {
        pilot = GameLoop.p;
        
    }


}
