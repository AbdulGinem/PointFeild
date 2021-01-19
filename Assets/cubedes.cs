using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubedes : MonoBehaviour
{

    public GameObject cube;

    

    void Start()
    {
        
        cube.transform.position = new Vector3(RandomGen.number, 1.50f, 40f);


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            DeathCount.score += 1;

        }
    }


}
