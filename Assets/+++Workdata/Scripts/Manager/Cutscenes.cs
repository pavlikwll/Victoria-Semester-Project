using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
  public GameObject cutsceneContainer;
  public List<GameObject> cutscenePanels;
  public Dialogue endDialogue;
  
  public Playercontroller playercontroller;
  public SceneLoader sceneLoader;
  
  private int currentPanel = 0;

  public void TriggerPanel()
  {
    StartCoroutine(PanelStartDelay());
  }

  private IEnumerator PanelStartDelay()
{
  yield return new WaitForSeconds(6f);
  OpenPanel();
}

public void OpenPanel()
  {
    cutsceneContainer.SetActive(true);
    playercontroller.DisablePlayerImput();
  }

  public void NextPanel()
  {
    playercontroller.DisablePlayerImput();
    cutscenePanels[currentPanel].SetActive(false);
    currentPanel++;
    
    if (currentPanel < cutscenePanels.Count)
    {
      cutscenePanels[currentPanel].SetActive(true);
    }
    else
    {
      cutsceneContainer.SetActive(false);
      playercontroller.EnablePlayerImput();

      if (endDialogue != null)
      {
        endDialogue.StartDialogue();
      }

      if (sceneLoader != null)
      {
        sceneLoader.EnterNextLevel();
      }
    }
  }

}
