using UnityEngine;

public class Lvl3_Quest : MonoBehaviour
{
    [Header("Objects to check")]
    public GameObject[] requiredObjects;

    [Header("Object to activate")]
    public GameObject objectToActivate;

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
        objectToActivate.SetActive(true);
    }
}