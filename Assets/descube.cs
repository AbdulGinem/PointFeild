using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class descube : MonoBehaviour
{
    
      void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "cube") {


            Destroy(gameObject);

        }

        if (other.gameObject.tag == "Player")
        {

            DeathCount.score = 0;

        }

    }
    
}
