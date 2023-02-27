using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStar : MonoBehaviour
{
   
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colli)
    {
        if(colli.gameObject.CompareTag("Player"))
        {
            EventManager.CountStart();
            Destroy(gameObject);
            
        }
        
    }
}
