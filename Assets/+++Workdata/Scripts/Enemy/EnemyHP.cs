using UnityEngine;
using UnityEngine.UI;


public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int maxPurification;
    [SerializeField]private int currentPurification;
    [SerializeField] private Image purificationBar;

    private void Awake()
    {
        currentPurification = maxPurification;
        UpdatePurificationBar();
    }
    // setzt beim Erstellen des Gameobjekts die currenthp auf die Max HP

    public void TakePurification(int pure)
    {
        currentPurification -= pure;
        if (currentPurification < 0)
        {
            currentPurification = 0;
        }
        
        UpdatePurificationBar();

        if (currentPurification <=0)
        {
            gameObject.SetActive(false);
        }
    }// Methode die Aufgerufen wir um Schaden zuzufügen und das Game Objekt zu deaktiveiren wenn HP auf 0 sinkern
    
    private void UpdatePurificationBar()
    {
        if (purificationBar == null)
        {
            return;
        }

        purificationBar.fillAmount = 1f - ((float)currentPurification / maxPurification);
    }
    
}
