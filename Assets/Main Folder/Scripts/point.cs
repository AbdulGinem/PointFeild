using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
 

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Hand")
        {
           
            PointCount.scoreValue += 1;
            Destroy(gameObject);
          

        }
    }



}
