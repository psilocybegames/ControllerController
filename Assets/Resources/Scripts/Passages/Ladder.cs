using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    private PilotController pilot;

	// Use this for initialization
	void Start ()
    {
        pilot = FindObjectOfType<PilotController>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2d (Collider2D other)
    {
		if(other == pilot)
        {
            pilot.SetIsOnLadder(true);
        }
	}

    void OnTriggerExit2d(Collider2D other)
    {
        if (other == pilot)
        {
            pilot.SetIsOnLadder(false);
        }
    }
}
