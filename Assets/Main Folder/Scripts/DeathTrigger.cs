using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
   


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           
            DeathCount.deathValue += 1;
            targets.targetValue = 1;
            
        }
    }
}
