using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatTracker : MonoBehaviour
{
    // Variables to track
    public int buildingsDestroyed;
    public int playerScore;
    public int earthquakeDestroyed;
    public int tornadoDestroyed;
    public int tsunamiDestroyed;


    public TextMeshProUGUI scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        #region Set Default Values
        buildingsDestroyed = 0;
        playerScore = 0;

        earthquakeDestroyed = 0;
        tornadoDestroyed = 0;
        tsunamiDestroyed = 0;
        #endregion

        scoreDisplay.text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void ScoreUpdate(int points)
    {
        playerScore += points;
        scoreDisplay.text = playerScore.ToString();
    }

    // Players love seeing these kinds of stats at the end of a game
    public void BuildingDestroyedBy(string disaster, int points)
    {
        buildingsDestroyed++;

        switch(disaster)
        {
            case "Earthquake":
                {
                    earthquakeDestroyed++;
                    break;
                }
            case "Tornado":
                {
                    tornadoDestroyed++;
                    break;
                }
            case "Tsunami":
                {
                    tsunamiDestroyed++;
                    break;
                }
        }

        ScoreUpdate(points);
    }
    
}
