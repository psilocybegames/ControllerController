using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {


    public static PilotController p;
	

    void Start()
    {



    }
	void Awake ()
    {
        p = GameObject.Find("ThePilot").GetComponent<PilotController>();	
	}
	
	void Update () {
		
	}
}
