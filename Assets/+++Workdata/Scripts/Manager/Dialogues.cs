using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public enum Speakers
     {Victoria, NPC}
    
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public GameObject endButton;
    public GameObject skipButton;
    
    public GameObject portraitVictoria;
    public GameObject portraitNPC;

    public List<string> dialogueLines;

    public int dialogueIndex;
    
    private bool dialogueActive;
    private int currentLine;
    
    public Playercontroller playercontroller;
    

    
    public void StartDialogue()
    {
        dialogueActive = true;
        
        dialoguePanel.SetActive(true);
        currentLine = 0;
        
        //StartCoroutine(AutoDialogue()); //kam beim dialog nicht so gut wie gedacht
        
        dialogueText.SetText(dialogueLines[currentLine]);
        Speakers currentSpeaker = GetCurrentSpeaker(currentLine); //soll den aktuellen sprecher ermitteln
        UpdatePortrait(currentSpeaker); //um dann das passende bild zu zeigen
        
        playercontroller.DisablePlayerImput();
        
        skipButton.SetActive(true);
    }
 
    /*IEnumerator AutoDialogue()
    {
        while (currentLine < dialogueLines.Count)
        {
            dialogueText.SetText(dialogueLines[currentLine]);
            Speakers currentSpeaker = GetCurrentSpeaker(currentLine); //soll den aktuellen sprecher ermitteln
            UpdatePortrait(currentSpeaker); //um dann das passende bild zu zeigen
            
            currentLine++; //dialog geht um einen weiter

            yield return new WaitForSeconds(5f); //zeigt automatisch nach 5 sekunden die nächste dialogzeile
        }
        skipButton.SetActive(false);
        endButton.SetActive(true);
    }*/

    public void SkipDialogue()
    {
        currentLine++; //dialog geht um einen weiter
        dialogueText.SetText(dialogueLines[currentLine]);
        Speakers currentSpeaker = GetCurrentSpeaker(currentLine); //soll den aktuellen sprecher ermitteln
        UpdatePortrait(currentSpeaker); //um dann das passende bild zu zeigen


        if (currentLine >= dialogueLines.Count - 1)
        {
        skipButton.SetActive(false);
        endButton.SetActive(true);
        }   
}

    public void EndDialogue()
    {
        
        dialogueActive = false;
        
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        endButton.SetActive(false);
        skipButton.SetActive(false);
   
        playercontroller.EnablePlayerImput();
    }

    void UpdatePortrait(Speakers currentSpeaker)
    {
        portraitVictoria.SetActive(currentSpeaker == Speakers.Victoria); //setzt dialogbild für victoria
        portraitNPC.SetActive(currentSpeaker == Speakers.NPC); //setzt dialogbild für npc
    }

    public Speakers GetCurrentSpeaker(int currentLine) //bestimmt den Sprecher
    {
        if (currentLine % 2 == 0)
            return Speakers.Victoria; //start mit Victoria, weil sie anspricht
        else
        {
            return Speakers.NPC; //player und npc wechseln sich ab
        }
    }
}