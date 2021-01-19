using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dobj : MonoBehaviour
{
    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    public GameObject o4;
    public GameObject o5;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Destroy(o1);
            Destroy(o2);
            Destroy(o3);
            Destroy(o4);
            Destroy(o5);


        }


    }
}
