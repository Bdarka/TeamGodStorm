using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DisasterType
{
    Earthquake, 
    Tornado, 
    Tsunami
}


public class PlayerController : MonoBehaviour
{
    public EarthquakeScript earthquake;
    public TornadoScript tornado;
    public TsunamiScript tsunami;

    // Start is called before the first frame update
    void Start()
    {
        earthquake = GetComponent<EarthquakeScript>();
        tornado = GetComponent<TornadoScript>();
        tsunami = GetComponent<TsunamiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            // earthquake.SetActive(true);
            // tornado.SetActive(false);
            // tsunami.SetActive(false);
        }

        if(Input.GetKey(KeyCode.E)) 
        {
            // earthquake.SetActive(false);
            // tornado.SetActive(true);
            // tsunami.SetActive(false);
        }

        if (Input.GetKey(KeyCode.T))
        {
            // earthquake.SetActive(false);
            // tornado.SetActive(false);
            // tsunami.SetActive(true);
        }
    }
}
