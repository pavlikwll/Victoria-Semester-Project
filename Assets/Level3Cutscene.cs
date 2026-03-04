using System;
using UnityEngine;

public class Level3Cutscene : MonoBehaviour
{
    public GameObject cutsceneContainer;
   
    public GameObject cutscene1;
    public GameObject cutscene2;
    public GameObject cutscene3;
    public GameObject cutscene4;
    public GameObject cutscene5;
    public GameObject cutscene6;
    public GameObject cutscene7;
    public GameObject cutscene8;
    public GameObject cutscene9;
    [SerializeField]private int cutsceneIndex;
    public Playercontroller playercontroller;
    public SceneLoader sceneLoader;
    private float _outrotime;
    private float _outrotimer;
    
    private void Awake()
    {
        cutsceneIndex= 0;
    }

    

    public void InteractCutscene()
    {
        InvokeRepeating("CutsceneButton", 2, 2);
        
    }
    
    public void CutsceneButton()
    {
        if (cutsceneIndex == 0)
        {
            cutsceneContainer.SetActive(true);
            cutscene1.SetActive(true);
            playercontroller.DisablePlayerImput();
            cutsceneIndex++;
        }
        else if (cutsceneIndex == 1)
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
            cutscene7.SetActive(true);
            
            cutsceneIndex++;

        }
        else if (cutsceneIndex == 7)
        {
            cutscene7.SetActive(false);
            cutscene8.SetActive(true);
            cutsceneIndex++;
        }
        else if (cutsceneIndex == 8)
            {
            cutscene8.SetActive(false);
            cutscene9.SetActive(true);
            cutsceneIndex++;
            
            }
        else if (cutsceneIndex == 9)
            {
            cutscene9.SetActive(false);
            sceneLoader.EnterNextLevel();
            }


    }
}
