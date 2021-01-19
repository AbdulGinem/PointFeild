using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObj : MonoBehaviour
{
    public GameObject Objects;


    // Start is called before the first frame update
    void Start()
    {
        Objects.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {


            Objects.SetActive(true);
        
        }
    }


}
