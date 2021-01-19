using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonT : MonoBehaviour
{

  


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            GetComponent<MeshRenderer>().enabled = false;
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
            }


            StartCoroutine(ExampleCoroutine());

        }
    }

    IEnumerator ExampleCoroutine()
    {
       
        yield return new WaitForSeconds(30f);
        GetComponent<MeshRenderer>().enabled = true;
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = true;
        }



    }


}
