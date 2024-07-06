using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Holds UI display values
public class DialogueUI : MonoBehaviour
{       
    [SerializeField] private TMP_Text textLabel;

    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<TypewriterEffect>().Run("This is progress on the dialogue system\nHow's your day?", textLabel);
    }

}
