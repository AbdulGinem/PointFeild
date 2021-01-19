using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefowrd : MonoBehaviour
{

    public GameObject obj;
    public Transform target;
    public float speed;
    private bool check = false;


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Hand")
        {
            
            check = true;
        }
        else
        {
            check = false;
        }
    }


   
    void Update()
    {
        if (check == true)
        {
            float step = speed * Time.deltaTime;
            Instantiate(obj);
           

        }
        else 
        {
            obj.transform.position = new Vector3(0.0f, 18.613f, 45.222f);
        }
    }
}



