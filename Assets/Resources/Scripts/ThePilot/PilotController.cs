using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotController : MonoBehaviour {

    public bool controlledByPilot = true;
    public bool controlledByAlien = false;

    public float horDir = 0f;
    public float verDir = 0f;
    public float moveSpeed = 2f;
    public float keyboardAxisBaseValue = 1f;
    
    SoundManager soundManagerInstance;
    public SpriteRenderer tentacles;

    public float removeKeyCounter = 0f;
    public float removeKeyTime = Config.keyRemovalTime;

    public SpriteRenderer sr;
    public Rigidbody2D r;
    public Animator a;

    public bool IsOnLadder;
    private float storedGravity;
    public List<KeyCode> pressedKeys;

    public UsableItem heldItem;
    private HeldItemBox heldItemBox;
    public bool clickedThisFrame = false;

    void Start () {
        a = transform.Find("Sprite").GetComponent<Animator>();
        pressedKeys = new List<KeyCode>();
        a.SetBool("Possesed", false);
        r = GetComponent<Rigidbody2D>();
        tentacles = transform.Find("Tentacles").GetComponent<SpriteRenderer>();
        heldItem = null;
        heldItemBox = FindObjectOfType<HeldItemBox>();
        soundManagerInstance = FindObjectOfType<SoundManager>();
    }
	
    public int checkForClick()
    {
        if (Input.GetKeyDown(Config.pickUpUseItemKey) || Input.GetKeyDown(Config.pickUpUseItemKeyboadKey))
        {
            return 1;
        }
        else
            return 0;
        
    }

	
	void Update ()
    {
        listenToControlSchemeChange();
        checkPlayerInput();
        removeKeysFromLoggedInput();
        	
	}

    public void listenToControlSchemeChange()
    {
        
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

        string axisNumber = "1";

        logKeyInput();
        handleKeyInput();
        
            if (controlledByPilot)
                axisNumber = "1";
            else
                axisNumber = "2";


       if(Input.GetAxis("HorizontalKeys"+ axisNumber) != 0f || Input.GetAxis("VerticalKeys" + axisNumber) != 0f)
           {
            horDir = Input.GetAxis("HorizontalKeys" + axisNumber);
            verDir = Input.GetAxis("VerticalKeys" + axisNumber);
           }
        else
            { 

        horDir = Input.GetAxis("Horizontal" + axisNumber);
        verDir = Input.GetAxis("Vertical" + axisNumber);
        }


        if (!IsOnLadder)
        {
            verDir = 0f;
        }

        if (horDir != 0 || verDir != 0)
            GetComponent<AudioSource>().UnPause();
        else
            GetComponent<AudioSource>().Pause();

    }

    public void handleKeyInput()
    {
   

        if (Input.GetKeyDown(Config.dropItemKey) || Input.GetKeyDown(Config.dropItemKeyboardKey))
            dropHeldItem();








    }

    public void LateUpdate()
    {

        clickedThisFrame = false;

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
        a.SetFloat("Speed", Mathf.Abs(horDir));
        if (horDir < 0)
            a.GetComponent<SpriteRenderer>().flipX = true;
        if(horDir > 0)
            a.GetComponent<SpriteRenderer>().flipX = false;

    }

    public void dropHeldItem()
    {
        if(heldItem != null)
        {
            heldItem.gameObject.transform.position = gameObject.transform.position;
            heldItem.GetComponent<Rigidbody2D>().velocity = new Vector2(UnityEngine.Random.Range(-2f, 2f), 2f);
            heldItem = null;
            GameLoop.changeCursorToDefault();
        }
    }

    public void pickUpItem(UsableItem pickedItem)
    {
        if(heldItem != null)
        {
            dropHeldItem();
        }
        heldItem = pickedItem;
        pickedItem.gameObject.transform.position = heldItemBox.getItemMovePosition();
        GameLoop.changeCursorSpriteTo(pickedItem.GetComponent<SpriteRenderer>().sprite);
    }

    public void switchSpriteToHuman()
    {
        
    }

    public void switchSpriteToAlien()
    {
        
    }
}
