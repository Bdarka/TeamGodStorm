using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] public GameObject canTalk;
    
    

    private void Start(){
        canTalk.SetActive(false);
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && other.TryGetComponent(out DefaultFormScript player)){
            player.Interactable = this;
            canTalk.SetActive(true);


        }
        
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player") && other.TryGetComponent(out DefaultFormScript player)){
            if(player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this){
                player.Interactable = null;
            }
            canTalk.SetActive(false);
        }
    }
    public void Ineract(DefaultFormScript player){
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
