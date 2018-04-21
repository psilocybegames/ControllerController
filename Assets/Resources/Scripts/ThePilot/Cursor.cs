using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    public float horDir = 0f;
    public float verDir = 0f;

	void Start () {
		
	}
	
	
	void Update () {

        horDir = Input.GetAxis("Cursor X");
        verDir = Input.GetAxis("Cursor Y");

    }

    void FixedUpdate()
    {

        transform.position += new Vector3(horDir, verDir, 0f) * Config.CursorSpeed;


    }
}
