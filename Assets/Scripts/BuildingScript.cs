using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    // To change how the building looks depending on damage level
    public List<Mesh> buildingModels = new List<Mesh>();
    public MeshFilter meshFilter;
    private Collider myCollider;
    private Rigidbody rb;

    // Reports score and destruction
    public StatTracker statTracker;

    public enum BuildingWeakness
    {
        Earthquake,
        Tornado,
        Tsunami
    }

    public enum BuildingResist
    {
        Earthquake,
        Tornado,
        Tsunami
    }

    // Building Health variables
    public BuildingWeakness Weakness;
    public BuildingResist Resistance;
    public int buildingHealth;
    public int buildingMaxHealth;

    // Determines how much it affects the player's score
    public int destructionPoints;
    private int buildingModelCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = buildingModels[0];

        myCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        statTracker = GameObject.FindObjectOfType<StatTracker>();
    }

    public void TakeDamage(string disaster)
    {
        if(disaster == Weakness.ToString())
        {
            buildingHealth -= 4;
            
        }
        else if(disaster == Resistance.ToString())
        {
            buildingHealth -= 3;
        }
        else
        {
            buildingHealth -= 2;
        }

        ChangeSprite(buildingHealth, disaster);
    }

    public void ChangeSprite(int health, string disaster)
    {

        if(health == buildingMaxHealth)
        {
            buildingModelCount = 0;
        }
        if(health <= 5)
        {
            buildingModelCount = 1;
        }
        if(health <= 0)
        {
            // Make the building change to destroyed, send information off the stat tracker and game manager
            buildingModelCount++;
            statTracker.BuildingDestroyedBy(disaster, destructionPoints);
            statTracker.GetComponent<GameManager>().TrackBuildings(this.gameObject);

            // Take this object out of physics calculations
            Destroy(myCollider);
            Destroy(rb);
        }

        meshFilter.mesh = buildingModels[buildingModelCount];
    }

}
