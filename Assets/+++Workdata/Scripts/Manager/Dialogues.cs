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

    public static Dialogue currentDialogue; //da die buttons mehrfach belegt sind, muss er checken, welchen dialog er skippen oder beenden soll
    
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public GameObject endButton;
    public GameObject skipButton;
    
    public GameObject portraitVictoria;
    public GameObject portraitNPC;

    public List<string> dialogueLines;
    public List<Speakers> speakerOrder; //muss gleich lang zu dialogueLines sein -> inspector

    public int dialogueIndex;
    private int currentLine;
    
    public Playercontroller playercontroller;
    

    
    public void StartDialogue()
    {
        currentDialogue = this;
        currentLine = 0;
        
        dialoguePanel.SetActive(true);
        skipButton.SetActive(true);

        playercontroller.DisablePlayerImput(); // not my typo, gez. Ronja

        ShowCurrentLine();
        
        //StartCoroutine(AutoDialogue()); //kam beim dialog nicht so gut wie gedacht
        
        skipButton.GetComponent<Button>().onClick.RemoveAllListeners();
        skipButton.GetComponent<Button>().onClick.AddListener(SkipDialogue);
        endButton.GetComponent<Button>().onClick.RemoveAllListeners();
        endButton.GetComponent<Button>().onClick.AddListener(EndDialogue);
    }

    private void ShowCurrentLine()
    {
        if (currentLine >= 0 && currentLine < dialogueLines.Count)
        {
            dialogueText.SetText(dialogueLines[currentLine]);
            UpdatePortrait(speakerOrder[currentLine]);
        }
    }

    public void SkipDialogue()
    {
        if (currentLine >= dialogueLines.Count - 1)
        {
            skipButton.SetActive(false);
            endButton.SetActive(true);
            return;
        }
        
        currentLine++; //dialog geht um einen weiter
        ShowCurrentLine();
    }
    
    public void EndDialogue()
    {
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        endButton.SetActive(false);
        skipButton.SetActive(false);
        portraitVictoria.SetActive(false);
        portraitNPC.SetActive(false);
   
        playercontroller.EnablePlayerImput(); //typo wasnt me
        
        currentDialogue = null;
    }
    
    private void UpdatePortrait(Speakers currentSpeaker)
         {
             portraitVictoria.SetActive(currentSpeaker == Speakers.Victoria); //setzt dialogbild für victoria
             portraitNPC.SetActive(currentSpeaker == Speakers.NPC); //setzt dialogbild für npc
         }
    
    /*IEnumerator AutoDialogue() //sah beim dialog nicht so gut aus - auto weiterlauf der textzeilen
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
}