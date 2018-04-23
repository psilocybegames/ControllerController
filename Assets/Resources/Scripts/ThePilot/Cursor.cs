using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private PilotController pilot;


    public void OnTriggerStay2D(Collider2D c)
    {
        if(c.GetComponent<InteractableObject>() != null)
        {
            InteractableObject i = c.GetComponent<InteractableObject>();
            i.onCursorOver();

            int click = GameLoop.p.checkForClick();
            if (click != 0)
                i.onCursorClick(click);
        }
    }

    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.GetComponent<InteractableObject>() != null)
        {
            InteractableObject i = c.GetComponent<InteractableObject>();
            i.onCursorExit();
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.GetComponent<InteractableObject>() != null)
        {
            InteractableObject i = c.GetComponent<InteractableObject>();
            i.onCursorEnter();
        }
    }

    public float horDir = 0f;
    public float verDir = 0f;

    void Start()
    {
        pilot = FindObjectOfType<PilotController>();
    }


    void Update()
    {

        string axisNumber = "1";
        if (GameLoop.p.controlledByAlien)
            axisNumber = "2";
            
        if(Input.GetAxis("Cursor XKeys" + axisNumber) != 0f || Input.GetAxis("Cursor YKeys" + axisNumber) != 0f)
        { 
            horDir = Input.GetAxis("Cursor XKeys" + axisNumber);
            verDir = Input.GetAxis("Cursor YKeys" + axisNumber);
        }
        else
        {


            horDir = Input.GetAxis("Cursor X" + axisNumber);
            verDir = Input.GetAxis("Cursor Y" + axisNumber);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(horDir, verDir) * Config.CursorSpeed + GameLoop.p.r.velocity;


      

    }
}
