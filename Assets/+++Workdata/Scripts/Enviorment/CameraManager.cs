using UnityEngine;
using UnityEngine.Events;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;
    
    public CinemachineCamera cm;

    public void Start()
    {
        cm = gameObject.GetComponent<CinemachineCamera>();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cm.Priority.Value = 10;
            Debug.Log("Trigger");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cm.Priority.Value = 0;
        }
    }
}