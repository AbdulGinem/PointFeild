using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headtrig : MonoBehaviour
{
    
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Head")
        {                                                                                                                                                                                                                                                                                                                                                                            

            player.transform.position = new Vector3(0.02f, 18.2f, 42.63f);

        }

        

    }



}
