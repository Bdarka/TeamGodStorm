using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScriptCameraLook : MonoBehaviour
{
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;    
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
