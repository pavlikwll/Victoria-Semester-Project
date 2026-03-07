using UnityEngine;

public class Sch_Quest : MonoBehaviour

{
    public Quest quest;

    [Header("UI")]
    public GameObject needCleanWebCanvas;

    [Header("Reward")]
    public GameObject partObject;   // off

    [Header("Dialogue")]
    public Dialogue dialogueNoPrism;
    public Dialogue dialoguePrismCollected;

    public GameObject prism;

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
        if (prism != null && prism.activeInHierarchy)
        {
            dialogueNoPrism.StartDialogue();
        }
        else
        {
            dialoguePrismCollected.StartDialogue();
        }

    }
}