using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;

// Holds UI display values
public class DialogueUI : MonoBehaviour
{       
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;
    [SerializeField] public GameObject portrait0;
    [SerializeField] public GameObject portriat1;


    public bool IsOpen{get; private set;}
    private TypewriterEffect typewriterEffect;

    // Start is called before the first frame update
    private void Start(){
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
        portrait0.SetActive(false);
        portriat1.SetActive(false);
        //ShowDialogue(testDialogue);

    }
    
    public void ShowDialogue(DialogueObject dialogueObject){
        IsOpen = true;
        
        dialogueBox.SetActive(true);
        portrait0.SetActive(true);
        portriat1.SetActive(true);

        StartCoroutine(StepThroughDialogue(dialogueObject));
    }


    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject){
        foreach (string dialogue in dialogueObject.Dialogue){
            yield return typewriterEffect.Run(dialogue, textLabel);

            //Next text line text key
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        CloseDialogueBox();
    }

    private void CloseDialogueBox(){
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        portrait0.SetActive(false);
        portriat1.SetActive(false);
    }

}
