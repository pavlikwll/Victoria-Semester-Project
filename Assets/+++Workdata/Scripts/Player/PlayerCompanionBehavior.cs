using System;
using UnityEngine;

public class PlayerCompanionBehavior : MonoBehaviour
{


    [SerializeField]private Playercontroller playerController;
    [SerializeField]private float speed;
    [SerializeField]private Transform followObject;
    [SerializeField]private GameObject visualRoot;

    private void Update()
    {
        
        transform.position = Vector2.MoveTowards(
            transform.position, followObject.position, speed * Time.deltaTime);
        //the Companion Objekt follows the Companion Target of the Player.
        if (playerController._starStateAvailable == StarStateAvailable.False)
        {
            visualRoot.SetActive(false);
        }
        else if (playerController._starStateAvailable == StarStateAvailable.True)
            {
            visualRoot.SetActive(true);
            }
        //Enables/Disables the visual Component of the Companion if its not Available.
    }
}
