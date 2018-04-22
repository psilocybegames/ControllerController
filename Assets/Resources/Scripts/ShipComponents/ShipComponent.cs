using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : InteractableObject
{
    private PilotController pilot;
    public bool isInRangeToUseObject;
    public UsableItem.ItemType itemNeeded;

    public virtual void ShipComponentActivated()
    {
        // I made it jump just for testing purposes
        Vector3 currentPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector3(currentPosition.x, currentPosition.y + 5, currentPosition.z);
    }

    public override void onCursorClick(int button)
    {
        //float pilotDistance Vector2.Distance(gameObject.transform.position, pilot.gameObject.transform.position);
        if (isInRangeToUseObject && pilot.heldItem.type == itemNeeded)
        {
            //Do something
            ShipComponentActivated();
        }
    }

    // Use this for initialization
    void Start ()
    {
        pilot = FindObjectOfType<PilotController>();
        isInRangeToUseObject = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PilotPickupRange")
        {
            isInRangeToUseObject = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "PilotPickupRange")
        {
            isInRangeToUseObject = false;
        }
    }
}
