using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    // To change how the building looks depending on damage level
    // commenting out 3D until sprites work
    // public List<Mesh> buildingModels = new List<Mesh>();
    // public MeshFilter meshFilter;
    public List<Sprite> buildingSprites = new List<Sprite>();
    public SpriteRenderer mySprite;
    private int buildingSpriteCount = 0;
    public Transform cam;
    private Collider myCollider;
    private Rigidbody rb;

    // Reports score and destruction
    public StatTracker statTracker;

    public enum BuildingWeakness
    {
        Earthquake,
        Tornado,
        Tsunami,
        Fire
    }

    public enum BuildingResist
    {
        Earthquake,
        Tornado,
        Tsunami,
        Fire
    }

    // Building Health variables
    public BuildingWeakness Weakness;
    public BuildingResist Resistance;
    public int buildingHealth;
    public int buildingMaxHealth;

    // Determines how much it affects the player's score
    public int destructionPoints;


    // Start is called before the first frame update
    void Start()
    {
       // meshFilter = GetComponent<MeshFilter>();
       // meshFilter.mesh = buildingModels[0];
       cam = Camera.main.transform;

        mySprite = GetComponent<SpriteRenderer>();
        mySprite.sprite = buildingSprites[0];

        myCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        statTracker = GameObject.FindObjectOfType<StatTracker>();
    }

    public void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    public void TakeDamage(string disaster, PlayerController playerController)
    {
        int buildingDamage = 0;
        Color color = Color.white;

        if(disaster == Weakness.ToString())
        {
            buildingDamage = 4;
            color = Color.green;
            destructionPoints = 100;
        }
        /*
        else if(disaster == Resistance.ToString())
        {
            buildingHealth -= 1;
        }
        */

        else
        {
            buildingDamage = 2;
            color = Color.red;
            destructionPoints = -100;
        }

        buildingHealth -= buildingDamage;
        playerController.ShowDamage(buildingDamage, color);

        ChangeSprite(buildingHealth, disaster);

        if(buildingHealth >= 0)
        {
            statTracker.BuildingDestroyedBy(disaster, destructionPoints);
        }
    }

    public void ChangeSprite(int health, string disaster)
    {

        if(health == buildingMaxHealth)
        {
            buildingSpriteCount = 0;
        }
        if(health <= 5)
        {
            buildingSpriteCount = 1;
        }
        if(health <= 0)
        {
            // Make the building change to destroyed, send information off the stat tracker and game manager
            buildingSpriteCount++;
            statTracker.BuildingDestroyedBy(disaster, destructionPoints);
            statTracker.GetComponent<GameManager>().TrackBuildings(this.gameObject);

            // Take this object out of physics calculations
            Destroy(myCollider);
            Destroy(rb);
        }

        // meshFilter.mesh = buildingModels[buildingSpriteCount];
        mySprite.sprite = buildingSprites[buildingSpriteCount];
    }

}
