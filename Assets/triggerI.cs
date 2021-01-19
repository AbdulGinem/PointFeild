using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class triggerI : MonoBehaviour
{

    public GameObject canvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            nearobject.fast = true;
            canvas.SetActive(true);
            nearobject.challenged = true;
        }
    }




}
