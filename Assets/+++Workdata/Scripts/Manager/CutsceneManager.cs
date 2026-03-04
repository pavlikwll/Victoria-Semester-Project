using System;
using UnityEditor;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
   public GameObject cutsceneContainer;
   public GameObject cutsceneButton;
   public GameObject cutscene1;
   public GameObject cutscene2;
   public GameObject cutscene3;
   public GameObject cutscene4;
   public GameObject cutscene5;
   public GameObject cutscene6;
   private int cutsceneIndex;
   public DialogManager dialogManager;
   public Playercontroller playercontroller;
   
   private void Awake()
   {
      
      cutsceneContainer.SetActive(true);
      cutscene1.SetActive(true);
      cutscene2.SetActive(false);
      cutscene3.SetActive(false);
      cutscene4.SetActive(false);
      cutscene5.SetActive(false);
      cutscene6.SetActive(false);
      cutsceneButton.SetActive(true);
      cutsceneIndex= 1;
      
   }

   private void Start()
   {
      playercontroller.DisablePlayerImput();
   }

   public void CutsceneButton()
   {
      if (cutsceneIndex == 1)
      {
         cutscene1.SetActive(false);
         cutscene2.SetActive(true);
         cutsceneIndex++;
      }
      else if (cutsceneIndex == 2)
         {
         cutscene2.SetActive(false);
         cutscene3.SetActive(true);
         cutsceneIndex++;
         }
      else if (cutsceneIndex == 3)
         {
         cutscene3.SetActive(false);
         cutscene4.SetActive(true);
         cutsceneIndex++;
         }
      else if (cutsceneIndex == 4)
         {
         cutscene4.SetActive(false);
         cutscene5.SetActive(true);
         cutsceneIndex++;
         }
      else if (cutsceneIndex == 5)
         {
         cutscene5.SetActive(false);
         cutscene6.SetActive(true);
         cutsceneIndex++;
         }
      else if (cutsceneIndex == 6)
         {
         cutscene6.SetActive(false);
         cutsceneContainer.SetActive(false);
         dialogManager.DisplayDialog();
         }
   }
   
}
