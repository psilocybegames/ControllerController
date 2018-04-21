﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotController : MonoBehaviour {

    public bool controlledByPilot = true;
    public bool controlledByAlien = false;

    public float horDir = 0f;
    public float verDir = 0f;
    public float moveSpeed = 2f;


    public float removeKeyCounter = 0f;
    public float removeKeyTime = Config.keyRemovalTime;

    public SpriteRenderer sr;
    public Rigidbody2D r;
    public Animator a;

    private bool IsOnLadder;
    private float storedGravity;
    public List<KeyCode> pressedKeys;
    void Start () {

        pressedKeys = new List<KeyCode>();

        r = GetComponent<Rigidbody2D>();
		
	}
	
    public int checkForClick()
    {

        return 0;

    }

	
	void Update ()
    {

        checkPlayerInput();
        removeKeysFromLoggedInput();
        	
	}

    public void removeKeysFromLoggedInput()
    {
        if (removeKeyCounter > removeKeyTime)
        {
            removeKeyCounter = 0f;

            if (pressedKeys.Count > 0)
                pressedKeys.RemoveAt(0);

        }
        else
            removeKeyCounter += Time.deltaTime;



    }

    public void SetIsOnLadder(bool value)
    {
        if(value)
        {
            storedGravity = r.gravityScale;
            r.gravityScale = 0f;
        }
        else
        {
            r.gravityScale = storedGravity;
        }
        IsOnLadder = value;
    }

    public void checkPlayerInput()
    {

        // Add difference with controlledBy flags
        string axisNumber = "1";

        logKeyInput();

        if (controlledByPilot)
            axisNumber = "1";
        else
            axisNumber = "2";

        horDir = Input.GetAxis("Horizontal" + axisNumber);
        verDir = 0f;

        if(IsOnLadder)
        {
            verDir = Input.GetAxis("Vertical" + axisNumber);
        }

        

    }

    public void logKeyInput()
    {
        
        foreach(KeyCode c in Config.buttons)
        {
            if (Input.GetKey(c))
                pressedKeys.Add(c);
        }

    }

    public void FixedUpdate()
    {
        r.velocity = new Vector3(moveSpeed * horDir,moveSpeed * verDir,0f);


    }
}
