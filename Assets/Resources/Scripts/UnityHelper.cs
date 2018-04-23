using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UnityHelper
{


    public static void zeroTransform(Transform t)
    {
        t.localRotation = Quaternion.Euler(0f, 0f, 0f);
        
        t.localPosition = Vector3.zero;
        t.localScale = Vector3.one;


        
    }

    public static void setActiveRecursively(bool v, Transform transform)
    {
        foreach(Transform t in transform)
        {
            foreach(Transform tt in t)
            {

                tt.gameObject.SetActive(v);

            }

            t.gameObject.SetActive(v);
        }

    }

    public static string ColorText(string researchedSubjectDisplayText, Color c)
    {
        string color = ColorUtility.ToHtmlStringRGB(c);

        string s = "<color=#"+color+">" + researchedSubjectDisplayText + "</color>";

        return s;
    }

    public static Color ColorFromHex(string v)
    {
        Color c;
        ColorUtility.TryParseHtmlString(v, out c);

        return c;

    }

  


    
    public static bool changeSpriteRendererColor(Color nc, SpriteRenderer s, float speed)
    {
        Color c = s.color;
        c = ColorMoveTowards(c, nc, speed);
        s.color = c;
        if (c.r == nc.r && c.g == nc.g && c.b == nc.b && c.a == nc.a)
            return true;


        return false;

    }

   

    public static string getWordForDirection(Vector2 src, Vector2 dst)
    {

        string[] words = new string[8];
        
        words[0] = "north";
        words[1] = "northeast";
        words[2] = "east";
        words[3] = "southeast";
        words[4] = "south";
        words[5] = "southwest";
        words[6] = "west";
        words[7] = "northwest";


        Vector2 dif = (dst - src);

        float angle = Mathf.Atan2(dif.x, dif.y) * Mathf.Rad2Deg;
        
        if (angle < 0)
        {
            angle = 360f - Mathf.Abs(angle);


        }

        
        float width = 45f / 2f;

        int i = (int) ((angle + width) / (2f * width));
        return words[i];



    }

    public static bool moveObjectTowards(GameObject gameObject, Vector3 position, float v)
    {

        if (gameObject.transform.position == position)
            return true;
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, position, v);
            return false;
        }

    }

    
    internal static Color ColorMoveTowards(Color color, Color change, float rate = 0.01f)
    {
        float da = color.a;
        float ta = change.a;

        Vector3 d = ColorToVector3(color);
        Vector3 t = ColorToVector3(change);

        d = Vector3.MoveTowards(d, t, rate);

        float adest = Mathf.MoveTowards(da, ta, rate);

        color = Vector3ToColor(d);
        color.a = adest;
        
        return color;
    }


    internal static string vector3ToString(Vector3 v)
    {
        string s = v.x.ToString() + "|";
        s += v.y.ToString() + "|";
        s += v.z.ToString();
        return s;
    }


    internal static Vector3 stringToVector3(string s)
    {
        Vector3 ret = new Vector3();
        string[] help = s.Split('|');
        ret.x = float.Parse(help[0]);
        ret.y = float.Parse(help[1]);
        ret.z = float.Parse(help[2]);

        return ret;
    }

    internal static Color Vector3ToColor(Vector3 d)
    {
        Color c = new Color(d.x, d.y, d.z, 1f);
        return c;
    }

    internal static Vector3 ColorToVector3(Color change)
    {
        Vector3 v = new Vector3(change.r, change.g, change.b);
        return v;
    }

  

    public static Vector3 calculateProgressBarPosition(float maskLength, float progress)
    {
        Vector3 v = Vector3.zero;

        v.x = -(1f - progress) * maskLength/2f;

        return v;

    }

    public static void putAtMouseScreenPosition(GameObject g, float x = 0f, float y = 0f)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = (mousePos - (new Vector3(Screen.width / 2f, Screen.height / 2f, 0f))) / GameObject.Find("Canvas").GetComponent<Canvas>().scaleFactor;
        mousePos.z = 0f;
       
        
        Transform p = g.transform.parent;
        g.transform.localPosition = mousePos;
           while (p != null)
           {
            if (p.name == "Canvas")
                   break;
               g.transform.localPosition -= p.localPosition;
               p = p.parent;
            


           }
       
        g.transform.localPosition += new Vector3(x, y, 0f);
        

    }

    public static bool fadeInSprite(SpriteRenderer s, float speed = 1f,bool unscaled = false)
    {
    
        Color c = s.color;
        float dT = 0f;
        if(unscaled)
            dT = Time.unscaledDeltaTime;
        else
            dT = Time.deltaTime;

       
        if (c.a < 1f)
        {
            c.a += dT * speed;
            s.color = c;
            return false;
        }
        else
        {
            c.a = 1f;
            s.color = c;
            return true;
        }

    }

    public static bool fadeOutSprite(SpriteRenderer s, float speed = 0.1f, bool unscaled = false, float targetAlpha = 0.01f)
    {
        Color c = s.color;

        float dT = 0f;
        if (unscaled)
            dT = Time.unscaledDeltaTime;
        else
            dT = Time.deltaTime;

        if (dT > 0.5f)
            dT = 0.1f;
        if (c.a > targetAlpha)
        {
            c.a -= dT * speed;
            s.color = c;
            return false;
        }
        else
        {
            c.a = targetAlpha;
            s.color = c;
            return true;
        }
        
    }

    public static float calculateLengthOfMessage(string message, Text t)
    {
        // Nonlinear unfortunately
        
        return message.Length * t.fontSize/2f;

      

        
    }


    public static Vector3 QuarterOfScreen()
    {
        float cScale = GameObject.Find("Canvas").GetComponent<Canvas>().scaleFactor;
        Vector3 result = new Vector3(Screen.width / (4f * cScale), 0f, 0f);
        return result;

        


    }

    internal static Vector3 flipX(Vector3 originalPosition, float flip = -1f)
    {
        return new Vector3(flip * originalPosition.x, originalPosition.y, originalPosition.z);

    }

    internal static Vector3 flipZ(Vector3 originalRotation, float flipped =-1f)
    {
        return new Vector3(originalRotation.x, originalRotation.y, flipped * originalRotation.z);
    }

    public static void destroyAllChildrenRecursively(GameObject g)
    {
        
        foreach(Transform t in g.transform)
        {
            destroyAllChildrenRecursively(t.gameObject);
            GameObject.Destroy(t.gameObject);

           

        }
    }

    public static string getStringPart(string s, string data)
    {

        
        s = "[" + s + "]";

        string e = s;
        e = e.Insert(1, "/");

        

        int l = data.IndexOf(e) - data.IndexOf(s) - (e.Length - 1);
        
        if (data.IndexOf(s) != -1 && data.IndexOf(e) != -1)
            return data.Substring(data.IndexOf(s) + s.Length,l);
        else
            return "";


    }
}
