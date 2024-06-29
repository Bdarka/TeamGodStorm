using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour
{
    public int buildingsDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        buildingsDestroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementBuildings()
    {
        buildingsDestroyed++;
        Debug.Log(buildingsDestroyed + " buildings destroyed");
    }
}
