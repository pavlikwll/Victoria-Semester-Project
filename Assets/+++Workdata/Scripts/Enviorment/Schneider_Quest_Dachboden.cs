using UnityEngine;

public class Sch_Quest : MonoBehaviour

{
    public Quest quest;

    [Header("UI")]
    public GameObject needCleanWebCanvas;

    [Header("Reward")]
    public GameObject partObject;   // off

    [Header("Dialogue")]
    public Dialogue dialogueNotCollected;
    public Dialogue dialogueCollected;

    public GameObject collectible;

    public void InteractWithSch()
    {
        if (!quest.webCleaned)
        {
            if (needCleanWebCanvas != null)
            {
                needCleanWebCanvas.SetActive(true);
            }
            return;
        }

        if (needCleanWebCanvas != null)
        {
            needCleanWebCanvas.SetActive(false);
        }
        if (partObject != null)
        {
            partObject.SetActive(true);
        }
    }

    public void DialogueInteraction()
    {
        if (collectible != null && collectible.activeInHierarchy)
        {
            dialogueNotCollected.StartDialogue();
        }
        else
        {
            dialogueCollected.StartDialogue();
        }

    }
}