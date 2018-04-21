using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthBar : MonoBehaviour {

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
        float width = filler.sprite.bounds.size.x;

        sm.transform.localScale = new Vector3(1f - percentFilled, 1f, 1f);
        float offset = (width * percentFilled)/2f;
        sm.transform.localPosition = new Vector3(offset, sm.transform.localPosition.y, sm.transform.localPosition.z);
    }
}
