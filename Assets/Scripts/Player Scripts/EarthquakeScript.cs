using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeScript : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {

        }

       if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

        }

       if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

        }

       if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

        }
    }
}
