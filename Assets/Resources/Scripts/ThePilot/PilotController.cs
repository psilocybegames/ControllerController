﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotController : MonoBehaviour {

    public bool controlledByPilot = true;
    public bool controlledByAlien = false;

    public float horDir = 0f;
    public float verDir = 0f;

    public SpriteRenderer sr;
    public Rigidbody2D r;
    public Animator a;
	void Start () {

        r = GetComponent<Rigidbody2D>();
		
	}
	
	
	void Update ()
    {

        checkPlayerInput();
        
        	
	}

    public void checkPlayerInput()
    {

        // Add difference with controlledBy flags
         horDir = Input.GetAxis("Horizontal");
         verDir = Input.GetAxis("Vertical");



    }

    public void FixedUpdate()
    {
        r.velocity = new Vector3(horDir,0f,0f);


    }
}