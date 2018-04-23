using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicShadow : MonoBehaviour {

    public SpriteRenderer sr;
	void Update ()
    {
        GetComponent<SpriteRenderer>().sprite = sr.sprite;
        GetComponent<SpriteRenderer>().flipX = sr.flipX;
	}
}
