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
    public GameObject defaultForm;

    // Seperates player abilities so that they have their own movement + colliders
    public EarthquakeScript earthquake;
    public TornadoScript tornado;
    public TsunamiScript tsunami;

    // Physics Components
    [HideInInspector]public Rigidbody rb;
    public Collider myCollider;
    public Vector3 movement;
    public float moveSpeed;
    [HideInInspector]public float x, z;

    // Switching to Different Forms
    public List<GameObject> disasterForms = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        earthquake = GetComponent<EarthquakeScript>();
        tornado = GetComponent<TornadoScript>();
        tsunami = GetComponent<TsunamiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;


        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");


        // Movement Buttons
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
           // transform.position = new Vector3 (x, 0, z) * moveSpeed * Time.deltaTime;
           // rb.velocity = new Vector3 (x, 0f, z);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

        }


        #region Form Switch Buttons
        if (Input.GetKey(KeyCode.R))
        {
            defaultForm.SetActive(false);
            SwitchDisasterType("Earthquake");
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

        if( Input.GetKey(KeyCode.Q)) 
        {
            
        }

        #endregion
    }

    public void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
    }

    public void SwitchDisasterType(string newDisaster)
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
