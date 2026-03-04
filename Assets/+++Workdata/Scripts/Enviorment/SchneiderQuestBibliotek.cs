using UnityEngine;

public class SchneiderQuestBibliotek : MonoBehaviour
{
    public bool objektCollected;
    public SceneLoader sceneLoader;

    private void Awake()
    {
        objektCollected = false;
    }

    public void Collected()
    {
        objektCollected = true;
    }

    public void LoadLevel2()
    {
        if (objektCollected == false) return;
        sceneLoader.EnterNextLevel();
    }
}
