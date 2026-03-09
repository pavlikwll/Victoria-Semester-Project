using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] private SchneiderQuestBibliotek quest;

    public void Collect()
    {
        Debug.Log("Brush collected");

        if (quest != null)
        {
            Debug.Log("Quest found: " + quest.name);
            quest.Collected();
        }
        else
        {
            Debug.LogError("Quest reference is NULL");
        }

        Destroy(gameObject);
    }
}