using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]private int _currentHP;
    [SerializeField] private int _maxHP;

    private void Awake()
    {
        _currentHP = _maxHP;
    }
    // setzt beim Erstellen des Gameobjekts die currenthp auf die Max HP

    public void TakeDmg(int dmg)
    {
        _currentHP -= dmg;
        if (_currentHP <= 0)
        {
            gameObject.SetActive(false);
            
        }
    }// Methode die Aufgerufen wir um Schaden zuzufügen und das Game Objekt zu deaktiveiren wenn HP auf 0 sinkern
}
