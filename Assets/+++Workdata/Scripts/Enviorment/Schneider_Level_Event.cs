using UnityEngine;

public class Schneider_Leve_Event : MonoBehaviour
{
    [SerializeField] private SchneiderQuestBibliotek quest;
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private Cutscenes cutscenes;

    private bool _eventStarted;

    public void StartEvent()
    {
        if (_eventStarted)
        {
            return;
        }

        if (quest == null)
        {
            return;
        }

        _eventStarted = true;

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy, 3f);
        }

        Invoke(nameof(LoadNextLevel), 4f);
    }

    private void LoadNextLevel()
    {
        if (sceneLoader != null)
        {
            sceneLoader.EnterNextLevel();
        }
    }
}