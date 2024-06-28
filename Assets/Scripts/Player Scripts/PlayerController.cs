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
    // Seperates player abilities so that they have their own movement + colliders
    public EarthquakeScript earthquake;
    public TornadoScript tornado;
    public TsunamiScript tsunami;

    // Physics Components
    public Rigidbody rb;
    public Collider myCollider;
    public List<GameObject> disasterModels = new List<GameObject>(); 

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
            earthquake.enabled = true;
            tornado.enabled = false;
            tsunami.enabled = false;
            // SwitchDisasterType("Earthquake");
        }

        if(Input.GetKey(KeyCode.E)) 
        {
            earthquake.enabled = false;
            tornado.enabled = true;
            tsunami.enabled = false;
            SwitchDisasterType("Tornado");
        }

        if (Input.GetKey(KeyCode.T))
        {
            earthquake.enabled = false;
            tornado.enabled = false;
            tsunami.enabled = true;
            SwitchDisasterType("Tsunami");
        }
    }

    public void SwitchDisasterType(string newDisaster)
    {

        for (int i = 0; i < disasterModels.Count; i++)
        {
            if (disasterModels[i].name != newDisaster)
            {
                disasterModels[i].gameObject.SetActive(false);
            }
            else
            {
                disasterModels[i].gameObject.SetActive(true);
            }
        }
    }
}
