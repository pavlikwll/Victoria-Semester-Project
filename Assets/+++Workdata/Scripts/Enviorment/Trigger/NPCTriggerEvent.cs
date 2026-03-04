using UnityEngine;
using UnityEngine.Events;

public class NPCTriggerEvent : MonoBehaviour
{
    public UnityEvent onTriggerEnter2D;
    public UnityEvent onTriggerExit2D;
    public string tagName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagName))
        {
            onTriggerEnter2D?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagName))
        {
            onTriggerExit2D?.Invoke();
        }
    }
}
