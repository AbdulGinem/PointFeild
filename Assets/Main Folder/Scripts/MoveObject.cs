using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public GameObject zipline;
    public GameObject stpos;
    public GameObject endpos;


    void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "Hand") {

            Debug.Log("Zip Line Trigger Works");
            zipline.transform.position = new Vector3(0, 18.697f, 44.988f);
            stpos.transform.position = new Vector3(0, 18.697f, 44.988f);
            endpos.transform.position = new Vector3(0, 18.697f, 544.451f);


        }
    
    }





}
