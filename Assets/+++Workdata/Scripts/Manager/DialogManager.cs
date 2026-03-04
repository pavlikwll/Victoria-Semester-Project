using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogManager : MonoBehaviour
{
    public TextAsset inkFile;
    public GameObject textbox;
    public GameObject button;
    public GameObject dialogContainer;
    private Text message;
    public Playercontroller playercontroller;
    [Header("Dialog")]
    public GameObject dialog_0_1;
    public GameObject dialog_0_2;
    public GameObject dialog_0_3;
    public GameObject dialog_0_4;
    public GameObject dialog_0_5;
    public GameObject dialog_0_6;
    public GameObject dialog_0_7;
    public GameObject dialogImageVictoria;
    public GameObject dialogImageStar;
    private int dialogIndex;
    

    private static Story story;

    private void Awake()
    {
        dialogIndex = 0;
    }

    public void DisplayDialog()
    {
        if (dialogIndex == 0)
        {
            Dialog1();
        }
        else if (dialogIndex == 1)
        {
            Dialog02();
        }
        else if (dialogIndex == 2)
            {
            Dialog03();
            }
        else if (dialogIndex == 3)
        {
            Dialog04();
            
        }
        else if (dialogIndex == 4)
            {
            Dialog05();
            }
        else if (dialogIndex == 5)
        {
            Dialog06();
            
        }
        else if (dialogIndex == 6)
            {
            Dialog07();
            }
        else if (dialogIndex == 7)
        {
            Dialog0End();
        }
    }

    public void Dialog1()
    {
        
        dialogContainer.gameObject.SetActive(true);
        dialog_0_1.gameObject.SetActive(true);
        dialog_0_2.gameObject.SetActive(false);
        dialog_0_3.gameObject.SetActive(false);
        dialog_0_4.gameObject.SetActive(false);
        dialog_0_5.gameObject.SetActive(false);
        dialog_0_6.gameObject.SetActive(false);
        dialog_0_7.gameObject.SetActive(false);
        button.gameObject.SetActive(true);
        dialogImageVictoria.gameObject.SetActive(true);
        dialogImageStar.gameObject.SetActive(false);
        dialogIndex++;
    }
    
    public void Dialog02()
    {
        dialog_0_1.gameObject.SetActive(false);
        dialog_0_2.gameObject.SetActive(true);
        dialogImageVictoria.gameObject.SetActive(false);
        dialogImageStar.gameObject.SetActive(true);
        dialogIndex++;
    }

    public void Dialog03()
    {
        dialog_0_2.SetActive(false);
        dialog_0_3.gameObject.SetActive(true);
        dialogImageVictoria.gameObject.SetActive(true);
        dialogImageStar.gameObject.SetActive(false);
        dialogIndex++;
    }

    public void Dialog04()
    {
        dialog_0_3.SetActive(false);
        dialog_0_4.gameObject.SetActive(true);
        dialogImageVictoria.gameObject.SetActive(false);
        dialogImageStar.gameObject.SetActive(true);
        dialogIndex++;
    }

    public void Dialog05()
    {
        dialog_0_4.SetActive(false);
        dialog_0_5.gameObject.SetActive(true);
        dialogImageVictoria.gameObject.SetActive(true);
        dialogImageStar.gameObject.SetActive(false);
        dialogIndex++;
    }

    public void Dialog06()
    {
        dialog_0_5.SetActive(false);
        dialog_0_6.SetActive(true);
        dialogImageVictoria.gameObject.SetActive(false);
        dialogImageStar.gameObject.SetActive(true);
        dialogIndex++;
    }

    public void Dialog07()
    {
        dialog_0_6.SetActive(false);
        dialog_0_7.SetActive(true);
        dialogImageVictoria.gameObject.SetActive(true);
        dialogImageStar.gameObject.SetActive(false);
        dialogIndex++;
    }

    public void Dialog0End()
    {
        dialogContainer.gameObject.SetActive(false);
        playercontroller.EnablePlayerImput();
       dialogIndex =0; 
    }

}
