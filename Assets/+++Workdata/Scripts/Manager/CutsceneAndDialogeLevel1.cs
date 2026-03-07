using UnityEngine;

public class CutsceneAndDialogeLevel1 : MonoBehaviour
{
    public GameObject cutsceneContainer;
    public GameObject cutsceneButton;
    public GameObject cutscene1;
    public GameObject cutscene2;
    public GameObject cutscene3;
    public GameObject cutscene4;
    private int cutsceneIndex;
    public Playercontroller playercontroller;
    
    /*public GameObject dialogueContainer;
    public GameObject dialogueButton1;
    public GameObject dialogueButton2;
    private int dialogueIndex1;
    private int dialogueIndex2;
    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public GameObject dialogue4;
    public GameObject dialogue5;
    public GameObject dialogue6;
    public GameObject dialogue7;
    public GameObject dialogue8;
    public GameObject dialogue9;
    public GameObject dialogue10;
    public GameObject dialogue11;
    public GameObject dialogue12;
    public GameObject dialogue13;
    public GameObject dialogue14;
    public GameObject dialogue15;
    public GameObject dialogue16;
    public GameObject dialogue17;
    public GameObject dialogue18;
    public GameObject dialoqueImageVictoria;
    public GameObject dialogueImageAlfred;
    public GameObject dialogueImageSchneider;*/

    private void Start()
    {
        playercontroller.DisablePlayerImput();
        //dialogueIndex1 = 0;
        //dialogueIndex2 = 0;
        cutsceneIndex = 0;
        DisplayCutscene();
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
            Cutscene1_4();
            }
        else if (cutsceneIndex == 4)
        {
            CutsceneEnd();
        }
    }

    public void Cutscene1_1()
    {
        cutsceneButton.SetActive(true);
        cutsceneContainer.SetActive(true);
        cutscene1.SetActive(true);
        cutscene2.SetActive(false);
        cutscene3.SetActive(false);
        cutscene4.SetActive(false);
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
    public void Cutscene1_4()
    {
        cutscene3.SetActive(false);
        cutscene4.SetActive(true);
        cutsceneIndex++;
    }
    
    public void CutsceneEnd()
    {
        cutsceneContainer.SetActive(false);
        playercontroller.EnablePlayerImput();
        cutsceneIndex = 0;
    }
    #endregion
/*
    #region Dialogue 1

    public void DisplayDialogue1()
    {
        if (dialogueIndex1 == 0)
            {
            Dialogue1_1();
            }
        else if (dialogueIndex1 == 1)
        {
            Dialogue1_2();
        }
        else if (dialogueIndex1 == 2)
            {
            Dialogue1_3();
            }
        else if (dialogueIndex1 == 3)
        {
            Dialogue1_4();
        }
        else if (dialogueIndex1 == 4)
        {
            Dialogue1_5();
        }
        else if (dialogueIndex1 == 5)
        {
            Dialogue1_6();
        }
        else if (dialogueIndex1 == 6)
        {
            Dialogue1_7();
        }
        else if (dialogueIndex1 == 7)
        {
            Dialogue1_8();
        }
        else if (dialogueIndex1 == 8)
        {
            Dialogue1End();
        }
    }

    private void Dialogue1_1()
    {
        playercontroller.DisablePlayerImput();
        dialogueContainer.SetActive(true);
        dialogueButton1.SetActive(true);
        dialogue1.SetActive(true);
        dialoqueImageVictoria.SetActive(true);
        dialogueIndex1++;
    }
    public void Dialogue1_2()
    {
        dialogue1.SetActive(false);
        dialogue2.SetActive(true);
        dialoqueImageVictoria.SetActive(false);
        dialogueImageAlfred.SetActive(true);
        dialogueIndex1++;
        
    }
    public void Dialogue1_3()
    {
        dialogue2.SetActive(false);
        dialogue3.SetActive(true);
        dialoqueImageVictoria.SetActive(true);
        dialogueImageAlfred.SetActive(false);
        dialogueIndex1++;
        
    }
    public void Dialogue1_4()
    {
        dialogue3.SetActive(false);
        dialogue4.SetActive(true);
        dialoqueImageVictoria.SetActive(false);
        dialogueImageAlfred.SetActive(true);
        dialogueIndex1++;
    }
    public void Dialogue1_5()
    {
        dialogue4.SetActive(false);
        dialogue5.SetActive(true);
        dialoqueImageVictoria.SetActive(true);
        dialogueImageAlfred.SetActive(false);
        dialogueIndex1++;
    }
    public void Dialogue1_6()
    {
        dialogue5.SetActive(false);
        dialogue6.SetActive(true);
        dialoqueImageVictoria.SetActive(false);
        dialogueImageAlfred.SetActive(true);
        dialogueIndex1++;
    }
    public void Dialogue1_7()
    {
        dialogue6.SetActive(false);
        dialogue7.SetActive(true);
        dialoqueImageVictoria.SetActive(true);
        dialogueImageAlfred.SetActive(false);
        dialogueIndex1++;
    }
    public void Dialogue1_8()
    {
        dialogue7.SetActive(false);
        dialogue8.SetActive(true);
        dialoqueImageVictoria.SetActive(false);
        dialogueImageAlfred.SetActive(true);
        dialogueIndex1++;
    }
    public void Dialogue1End()
    {
        dialogue8.SetActive(false);
        dialogueIndex1 = 0;
        dialogueButton1.SetActive(false);
        dialogueImageAlfred.SetActive(false);
        dialogueContainer.SetActive(false);
        playercontroller.EnablePlayerImput();
    }
    
    #endregion
    
    #region Dialogue 2
    
    public void DisplayDialogue2()
    {
        if (dialogueIndex2 == 0)
        {
            Dialogue2_1();
        }
        else if (dialogueIndex2 == 1)
        {
            Dialogue2_2();
        }
        else if (dialogueIndex2 == 2)
        {
            Dialogue2_3();
        }
        else if (dialogueIndex2 == 3)
        {
            Dialogue2_4();
        }
        else if (dialogueIndex2 == 4)
        {
            Dialogue2_5();
        }
        else if (dialogueIndex2 == 5)
        {
            Dialogue2_6();
        }
        else if (dialogueIndex2 == 6)
        {
            Dialogue2_7();
        }
        else if (dialogueIndex2 == 7)
        {
            Dialogue2_8();
        }
        else if (dialogueIndex2 == 8)
        {
            Dialogue2_9();
        }
        else if (dialogueIndex2 == 9)
        {
            Dialogue2_10();
        }
        else if (dialogueIndex2 == 10)
        {
            Dialogue2End();
        }
    }

    public void Dialogue2_1()
    {
        playercontroller.DisablePlayerImput();
        dialogueContainer.SetActive(true);
        dialogue9.SetActive(true);
        dialogueButton2.SetActive(true);
        dialoqueImageVictoria.SetActive(true);
        dialogueIndex2++;
    }

    public void Dialogue2_2()
    {
        dialogue9.SetActive(false);
        dialogue10.SetActive(true);
        dialoqueImageVictoria.SetActive(false);
        dialogueImageSchneider.SetActive(true);
        dialogueIndex2++;
    }
    public void Dialogue2_3()
    {
        dialogue10.SetActive(false);
        dialogue11.SetActive(true);
        dialoqueImageVictoria.SetActive(true);
        dialogueImageSchneider.SetActive(false);
        dialogueIndex2++;
    }
    public void Dialogue2_4()
    {
        dialogue11.SetActive(false);
        dialogue12.SetActive(true);
        dialoqueImageVictoria.SetActive(false);
        dialogueImageSchneider.SetActive(true);
        dialogueIndex2++;
    }
    public void Dialogue2_5()
    {
        dialogue12.SetActive(false);
        dialogue13.SetActive(true);
        dialoqueImageVictoria.SetActive(true);
        dialogueImageSchneider.SetActive(false);
        dialogueIndex2++;
    }
    public void Dialogue2_6()
    {
        dialogue13.SetActive(false);
        dialogue14.SetActive(true);
        dialoqueImageVictoria.SetActive(false);
        dialogueImageSchneider.SetActive(true);
        dialogueIndex2++;
    }
    public void Dialogue2_7()
    {
        dialogue14.SetActive(false);
        dialogue15.SetActive(true);
        dialoqueImageVictoria.SetActive(true);
        dialogueImageSchneider.SetActive(false);
        dialogueIndex2++;
    }
    public void Dialogue2_8()
    {
        dialogue15.SetActive(false);
        dialogue16.SetActive(true);
        dialoqueImageVictoria.SetActive(false);
        dialogueImageSchneider.SetActive(true);
        dialogueIndex2++;
    }
    public void Dialogue2_9()
    {
        dialogue16.SetActive(false);
        dialogue17.SetActive(true);
        dialoqueImageVictoria.SetActive(true);
        dialogueImageSchneider.SetActive(false);
        dialogueIndex2++;
    }
    public void Dialogue2_10()
    {
        dialogue17.SetActive(false);
        dialogue18.SetActive(true);
        dialoqueImageVictoria.SetActive(false);
        dialogueImageSchneider.SetActive(true);
        dialogueIndex2++;
    }
    public void Dialogue2End()
    {
        dialogue18.SetActive(false);
        dialogueIndex2 = 0;
        dialogueButton2.SetActive(false);
        dialogueImageSchneider.SetActive(false);
        dialogueContainer.SetActive(false);
        playercontroller.EnablePlayerImput();
    }
    
    
    #endregion
    
    */
    
    
}
