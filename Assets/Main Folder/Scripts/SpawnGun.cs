using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGun : MonoBehaviour
{

    public GameObject gun;
    private bool hasgun = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gun);
        

    }


 
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Hand")
        {
           
            GetComponent<Collider>().enabled = false;
            StartCoroutine(Test());
            
        }
     
    }


    IEnumerator Test()
    {
        yield return new WaitForSeconds(5);
        Instantiate(gun);
        GetComponent<Collider>().enabled = true;
    }



}
