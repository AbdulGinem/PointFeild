using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObj : MonoBehaviour
{
    public GameObject Objects;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Objects.SetActive(false);

        }
    }
}
