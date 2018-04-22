using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private PilotController pilot;

    public float maximumDistance = 5;

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

        horDir = Input.GetAxis("Cursor X");
        verDir = Input.GetAxis("Cursor Y");

    }

    void FixedUpdate()
    {
        Vector3 newPosition = transform.position + new Vector3(horDir, verDir, 0f) * Config.CursorSpeed;

        if(Vector3.Distance(newPosition, pilot.gameObject.transform.position) <= maximumDistance)
            transform.position += new Vector3(horDir, verDir, 0f) * Config.CursorSpeed;

    }
}
