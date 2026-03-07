using UnityEngine;

public class Lvl3_Quest : MonoBehaviour
{
    [Header("Objects to check")]
    public GameObject[] requiredObjects;

    [Header("Object to activate")]
    public GameObject objectToActivate1;
    public GameObject objectToActivate2;
    public Cutscenes cutscenes;
    
    public void CheckAndActivate()
    {
        foreach (GameObject obj in requiredObjects)
        {
            if (obj == null || !obj.activeInHierarchy)
            {
                Debug.Log("Умови не виконані");
                return;
            }
        }

        Debug.Log("Усі умови виконані");
        objectToActivate1.SetActive(true);
        objectToActivate2.SetActive(true);
        cutscenes.TriggerPanel();
        
    }
}