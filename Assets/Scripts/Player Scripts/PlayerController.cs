using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    // Audio Components
    public MusicManager musicManager;
    public SFXManager sFXManager;

    // Portrait Switch 
    public UnityEngine.UI.Image portraitSprite;
    public List<Sprite> portraitSpritesList = new List<Sprite>();

    // Seperates player abilities so that they have their own movement + colliders
    public EarthquakeScript earthquake;
    public TornadoScript tornado;
    public TsunamiScript tsunami;

    // Switching to Different Forms
    public List<GameObject> disasterForms = new List<GameObject>();
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
            sFXManager.PlaySFX("Earth - (GODSTORM)");
        }

        if(Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3)
            && canTornado == true) 
        { 
            SwitchForm("Tornado");
            musicManager.ChangeSong("Wind (Demo)");
            sFXManager.PlaySFX("Wind - (GODSTORM)");
        }

        if (Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Keypad4)
            && canTsunami == true)
        {
            SwitchForm("Tsunami");
            musicManager.ChangeSong("Water (Demo)");
            sFXManager.PlaySFX("Water - (GODSTORM)");
        }

        if(Input.GetKey(KeyCode.Alpha5) || Input.GetKey(KeyCode.Keypad5)
            && canFire == true)
        {
            SwitchForm("Fire");
            musicManager.ChangeSong("Fire (Demo)");
            sFXManager.PlaySFX("Fire - (GODSTORM)");
        }

        #endregion
    }

    public void SwitchForm(string newDisaster)
    {

        for (int i = 0; i < disasterForms.Count; i++)
        {
            disasterForms[i].gameObject.SetActive(false);

            if (disasterForms[i].name == newDisaster)
            {
                disasterForms[i].gameObject.SetActive(true);

                for (int j = 0; j < portraitSpritesList.Count; j++)
                {
                    if (portraitSpritesList[j].name == newDisaster)
                    {
                        portraitSprite.sprite = portraitSpritesList[j];
                    }
                }
            }
        }

/*
        for (int i = 0; i < disasterForms.Count; i++)
        {
            if (disasterForms[i].name != newDisaster)
            {
                
            }
            else
            {
                disasterForms[i].gameObject.SetActive(true);
                for(int j = 0; j < portraitSpritesList.Count; j++)
                {
                    if (portraitSpritesList[i].name == newDisaster)
                    {
                        portraitSprite.GetComponent<Image>().sprite = portraitSpritesList[j];
                    }

                }
            }
        }
*/
    }


}
