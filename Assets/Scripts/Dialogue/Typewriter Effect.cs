using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float typeSpeed = 25f; //SPEED
    public void Run(string textToType, TMP_Text textLable){

        StartCoroutine(TypeText(textToType, textLable));
    }



    //Types out string values.
    private IEnumerator TypeText(string textToType, TMP_Text textLabel){

        yield return new WaitForSeconds(3); //Time to wait before text shows.
        
        float t = 0;
        int charIndex = 0;  //holds whole number of length.

        while (charIndex < textToType.Length){

            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
