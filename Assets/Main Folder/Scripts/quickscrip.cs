using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickscrip : MonoBehaviour
{


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {

            targets.targetValue = 0;
        
        
        }



    }






}
