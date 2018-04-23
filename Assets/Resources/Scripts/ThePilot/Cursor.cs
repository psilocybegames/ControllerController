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
        if(GameLoop.p.controlledByAlien)
        { 
        horDir = Input.GetAxis("Cursor X2");
        verDir = Input.GetAxis("Cursor Y2");
        }
        else { 
        horDir = Input.GetAxis("Cursor X1");
        verDir = Input.GetAxis("Cursor Y1");
        }

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(horDir, verDir) * Config.CursorSpeed + GameLoop.p.r.velocity;


      

    }
}
