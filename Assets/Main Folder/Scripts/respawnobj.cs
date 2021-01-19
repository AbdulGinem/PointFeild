using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnobj : MonoBehaviour
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
            Instantiate(o1);
            Instantiate(o2);
            Instantiate(o3);
            Instantiate(o4);
            Instantiate(o5);

        }
    }

    
    
}
