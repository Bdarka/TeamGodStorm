using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public StatTracker StatTracker;

    public List<GameObject> objectsToDestroy = new List<GameObject>();
    public List<GameObject> objectsToSave = new List<GameObject>();

    public Transform destroyParent;
    public Transform saveParent;

    // Start is called before the first frame update
    void Start()
    {
       StatTracker = GetComponent<StatTracker>();

       foreach(Transform t in destroyParent)
        {
            objectsToDestroy.Add(t.gameObject);
        }

       foreach(Transform t in saveParent)
        {
            objectsToSave.Add(t.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
