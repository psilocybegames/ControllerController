using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour {


    public static Text t;
    public static SpriteRenderer bg;
    public static float disappearCounter = 0f;
    

	void Start () {

        t = transform.Find("MessageText").GetComponent<Text>();
        bg = transform.Find("MessageBarBackground").GetComponent<SpriteRenderer>();
        bg.gameObject.SetActive(false);

    }



    public static void showMessage(string s)
    {
        t.text = s;
        disappearCounter = Config.disappearMessageTime;
        bg.gameObject.SetActive(true);

    }
	public void Update ()
    {


        if (disappearCounter < 0)
        { 
            t.text = "";
            bg.gameObject.SetActive(false);

        }
        else
            disappearCounter -= Time.deltaTime;
        
        	
	}
}
