using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public List<GameObject> buildingModels = new List<GameObject>();

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

    public BuildingWeakness Weakness;
    public BuildingResist Resist;

    public int buildingHealth;
    public int buildingMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buildingModels.Count; i++)
        {
            if (i == 0)
            {
                buildingModels[i].gameObject.SetActive(true);
            }
            else
            {
                buildingModels[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(int health)
    {
        for(int i = 0;i < buildingModels.Count;i++)
        {
            buildingModels[i].gameObject.SetActive(false);
        }

        int buildingModelCount = 0;

        if(health == buildingMaxHealth)
        {
            buildingModelCount = 0;
        }
        if(health <= 8)
        {
            buildingModelCount++;
        }
        if(health <= 4)
        {
            buildingModelCount++;
        }
        if(health <= 0)
        {
            buildingModelCount++;
            statTracker.IncrementBuildings();
        }

        buildingModels[buildingModelCount].gameObject.SetActive(true);
    }
}
