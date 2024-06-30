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
        for(int i = 0; i < buildingModels.Count;i++)
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
            statTracker.BuildingDestroyedBy(disaster, destructionPoints);
        }

        buildingModels[buildingModelCount].gameObject.SetActive(true);
    }

}
