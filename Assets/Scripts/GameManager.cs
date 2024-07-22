using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public StatTracker StatTracker;

    // Keep track of what objects players need to destory. 
    // Convoluted I know but I wanted to make it easy enough for non-programmers to add it it
    public List<GameObject> objectsToDestroy = new List<GameObject>();
    public List<GameObject> objectsToSave = new List<GameObject>();
    public Transform destroyParent;
    public Transform saveParent;

    public TextMeshProUGUI tempText;

    public Scene GoodEnd;
    public Scene BadEnd;

    // Start is called before the first frame update
    void Start()
    {
        tempText.enabled = false;
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

    public void TrackBuildings(GameObject destroyedBuilding)
    {
        if(objectsToDestroy.Contains(destroyedBuilding))
        {
            objectsToDestroy.Remove(destroyedBuilding);

            Debug.Log(objectsToDestroy.Count);

            if(objectsToDestroy.Count == 0)
            {
                tempText.enabled = true;
                tempText.text = "You Win! You saved the planet!";
            }
        }
    }

    public void ShowEnding()
    {
        int score = StatTracker.playerScore;

        if(score > 0)
        {
            SceneManager.LoadScene(GoodEnd.name);
        }

        else 
        {
            SceneManager.LoadScene(BadEnd.name);
        }
    }
}
