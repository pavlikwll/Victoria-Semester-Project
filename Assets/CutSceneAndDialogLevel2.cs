using UnityEngine;

public class CutSceneAndDialogLevel2 : MonoBehaviour
{
    public GameObject cutsceneContainer;
    public GameObject cutscene1;
    public GameObject cutscene2;
    public GameObject cutscene3;
    private int cutsceneIndex;
    public Playercontroller playercontroller;
    public GameObject cutsceneButton;
  
    
    private void Start()
    {
        playercontroller.DisablePlayerImput();
        cutsceneIndex = 0;
         Invoke("DisplayCutscene", 0);
         
    }

    #region Cutscene

    

    
    public void DisplayCutscene()
    {
        if (cutsceneIndex == 0)
        {
            Cutscene1_1();
        }
        else if (cutsceneIndex == 1)
        {
            Cutscene1_2();
        }
        else if (cutsceneIndex == 2)
        {
            Cutscene1_3();
        }
        else if (cutsceneIndex == 3)
        {
            CutsceneEnd();
        }
    }
    
    public void Cutscene1_1()
    {
        cutsceneContainer.SetActive(true);
        cutsceneButton.SetActive(true);
        cutscene1.SetActive(true);
        cutscene2.SetActive(false);
        cutscene3.SetActive(false);
        cutsceneIndex++;
    }
    public void Cutscene1_2()
    {
        cutscene1.SetActive(false);
        cutscene2.SetActive(true);
        cutsceneIndex++;
        
    }
    public void Cutscene1_3()
    {
        cutscene2.SetActive(false);
        cutscene3.SetActive(true);
        cutsceneIndex++;
    }
   
    
    public void CutsceneEnd()
    {
        cutscene3.SetActive(false);
        cutsceneContainer.SetActive(false);
        playercontroller.EnablePlayerImput();
        cutsceneIndex = 0;
    }
    #endregion
    //Sry, aber ich hab keine Zeit mehr.
}
