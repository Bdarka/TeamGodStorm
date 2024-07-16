using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum DisasterType
{
    Earthquake, 
    Tornado, 
    Tsunami,
    Fire
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

    [HideInInspector] public bool canQuake;
    [HideInInspector] public bool canTornado;
    [HideInInspector] public bool canFire;
    [HideInInspector] public bool canTsunami;

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
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            SwitchForm("Angel");
            musicManager.ChangeSong("Calm (Demo)");
        }

        #region Form Change Inputs
        if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2)
            && canQuake == true)
        {
            SwitchForm("Earthquake");
            musicManager.ChangeSong("Earth (Demo)");
        }

        if(Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3)
            && canTornado == true) 
        { 
            SwitchForm("Tornado");
            musicManager.ChangeSong("Wind (Demo)");
        }

        if (Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Keypad4)
            && canTsunami == true)
        {
            SwitchForm("Tsunami");
            musicManager.ChangeSong("Water (Demo)");
        }

        if(Input.GetKey(KeyCode.Alpha5) || Input.GetKey(KeyCode.Keypad5)
            && canFire == true)
        {
            SwitchForm("Fire");
            musicManager.ChangeSong("Fire (Demo)");
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
