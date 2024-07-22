using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] public Sprite portriatLeft;
    [SerializeField] public Sprite portraitRight;

    [SerializeField] public GameObject image1;

    public string[] Dialogue => dialogue;
}
