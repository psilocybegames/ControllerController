using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : InteractableObject
{
    private PilotController pilot;
    public bool isPickable;

    public enum ItemType
    {
        ControlRod,
        PilotClearance,
        InhibitorReleaseKey,
        EngineerHud
    }

    public override void onCursorClick(int button)
    {
        //float pilotDistance Vector2.Distance(gameObject.transform.position, pilot.gameObject.transform.position);
        if (isPickable)
            pilot.pickUpItem(this);
    }

    public ItemType type;

    public bool UseItemOn(ShipComponent component)
    {
        return false;
    }
	// Use this for initialization
	void Start ()
    {
        pilot = FindObjectOfType<PilotController>();
        isPickable = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PilotPickupRange")
        {
            isPickable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "PilotPickupRange")
        {
            isPickable = false;
        }
    }
}
