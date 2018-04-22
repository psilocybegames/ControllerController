using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItemBox : MonoBehaviour {

    public Vector3 getItemMovePosition()
    {
        Vector3 currentPosition = gameObject.transform.position;
        return new Vector3(currentPosition.x, currentPosition.y+2, currentPosition.z);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
