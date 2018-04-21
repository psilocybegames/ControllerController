using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour {

    SpriteMask sm;
    SpriteRenderer filler;
    SpriteRenderer background;

    public float percentFilled = 0f;


	void Start ()
    {
        sm = transform.Find("FillerSpriteMask").GetComponent<SpriteMask>();
        filler = transform.Find("Filler").GetComponent<SpriteRenderer>();
        sm.sprite = filler.sprite;
        background = GetComponent<SpriteRenderer>();
	}
	
	
	void Update ()
    {

        setSpriteMaskSizeAndPosition();
        	
	}

    public void setSpriteMaskSizeAndPosition()
    {
        float height = filler.sprite.bounds.size.y;

        sm.transform.localScale = new Vector3(sm.transform.localScale.x, 1f - percentFilled, sm.transform.localScale.z);
        float offset = (height * percentFilled)/2f;
        sm.transform.localPosition = new Vector3(sm.transform.localPosition.x, offset, sm.transform.localPosition.z);
    }
}
