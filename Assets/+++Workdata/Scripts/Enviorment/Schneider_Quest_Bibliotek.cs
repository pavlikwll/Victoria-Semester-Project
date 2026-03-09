using UnityEngine;

public class SchneiderQuestBibliotek : MonoBehaviour
{
    [SerializeField] private bool objektCollected;
    [SerializeField] private Cutscenes cutscenes;
    [SerializeField] private GameObject objectToActivate;

    private bool _eventStarted;

    private void Awake()
    {
        objektCollected = false;
        _eventStarted = false;
        
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
    }

    public void Collected()
    {
        objektCollected = true;
        
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    public void Interact()
    {
        if (!objektCollected)
        {
            return;
        }

        if (_eventStarted) return;
        _eventStarted = true;

        if (cutscenes != null)
        {
            cutscenes.TriggerPanel();
        }
    }
}