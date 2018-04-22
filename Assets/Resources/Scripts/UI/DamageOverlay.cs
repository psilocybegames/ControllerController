using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverlay : MonoBehaviour {

    public bool engage = false;
    public float flashCounter = 0f;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
	
        if(engage)
        {
            if (flashCounter > Config.DamageFlashTime)
            {
                flashCounter = 0f;
                engage = false;

              
            }
            else
            {
                Color cc = GetComponent<SpriteRenderer>().color;
                if(cc.a < 1f)
                    cc.a += 0.1f;
                GetComponent<SpriteRenderer>().color = cc;
                flashCounter += Time.deltaTime;
            }

        }
        else
        {

            Color c = GetComponent<SpriteRenderer>().color;
            if(c.a > 0f)
                c.a -= 0.1f;
            GetComponent<SpriteRenderer>().color = c;


        }



    }
}
