using UnityEngine;

public class HealOnInteract : MonoBehaviour
{
    public int healAmount = 20;

    public void Heal()
    {
        PlayerHealth player = FindObjectOfType<PlayerHealth>();

        if (player == null)
        {
            return;
        }

        player.Heal(healAmount);
    }
}