using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Security.Cryptography;

public class dto : MonoBehaviour
{
    public GameObject thiss;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "TD")
        {

            thiss.transform.position = new Vector3(0, 3.55f, 40f);


        }
    
    
    }
}
