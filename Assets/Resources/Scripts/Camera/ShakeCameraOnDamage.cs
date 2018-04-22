using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraOnDamage : MonoBehaviour
{

    public Camera c;
    public void OnDisable()
    {
        c.transform.localPosition = Vector3.zero + new Vector3(0f,0f,-10f);
    }

    
    void Awake()
    {
        c = GetComponent<Camera>();
    }

    
    void FixedUpdate()
    {
        float xR = Random.Range(-Config.cameraShakeFactor, Config.cameraShakeFactor);
        float yR = Random.Range(-Config.cameraShakeFactor, Config.cameraShakeFactor);
        float zR = Random.Range(-Config.cameraShakeFactor, Config.cameraShakeFactor);

        c.transform.localPosition += new Vector3(xR, yR, zR);
    }
}
