using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour {


    public static Text t;
    public static Text st;

    public static SpriteRenderer bg;
    public static float disappearCounter = 0f;
    

	void Start () {

        t = transform.Find("MessageText").GetComponent<Text>();
        st = transform.Find("MessageSubText").GetComponent<Text>();

        bg = transform.Find("MessageBarBackground").GetComponent<SpriteRenderer>();
        bg.gameObject.SetActive(false);

    }



    public static void showMessage(string s)
    {
        t.text = s;

    }

    public static void showSubText(string s)
    {
        st.text = s;

    }

    public void Update ()
    {


        
        	
	}
}
