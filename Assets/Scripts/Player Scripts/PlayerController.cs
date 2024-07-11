using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    // Switching to Different Forms
    public List<GameObject> disasterForms = new List<GameObject>();

    public MusicManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        earthquake = disasterForms[2].gameObject.GetComponent<EarthquakeScript>();
        tornado = disasterForms[1].gameObject.GetComponent<TornadoScript>();
        tsunami = disasterForms[3].gameObject.GetComponent<TsunamiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Form Change Inputs
        if (Input.GetKey(KeyCode.R))
        {
            SwitchForm("Earthquake");
            musicManager.ChangeSong("crawl");
        }

        if(Input.GetKey(KeyCode.E)) 
        { 
            SwitchForm("Tornado");
            musicManager.ChangeSong("Honey Revenge - Airhead");
        }

        if (Input.GetKey(KeyCode.T))
        {
            SwitchForm("Tsunami");
            musicManager.ChangeSong("Sabrina Carpenter-Espresso");
        }

        if( Input.GetKey(KeyCode.Q)) 
        {
            SwitchForm("Angel");
            musicManager.ChangeSong("RATATATA");
        }

        #endregion
    }

    public void SwitchForm(string newDisaster)
    {

        for (int i = 0; i < disasterForms.Count; i++)
        {
            if (disasterForms[i].name != newDisaster)
            {
                disasterForms[i].gameObject.SetActive(false);
            }
            else
            {
                disasterForms[i].gameObject.SetActive(true);
            }
        }
    }
}
