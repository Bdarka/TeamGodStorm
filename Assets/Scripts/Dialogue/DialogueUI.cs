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
    [SerializeField] private Image image;


    private TypewriterEffect typewriterEffect;

    // Start is called before the first frame update
    private void Start(){
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
        ShowdDialogue(testDialogue);
    }
    
    public void ShowdDialogue(DialogueObject dialogueObject){
        dialogueBox.SetActive(true);
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
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

}
