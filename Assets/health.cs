using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public float Health;
    
    



    void Start()
    {
        Health = 100;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Health -= 1 * Time.deltaTime;
        }
    }

    void Update()
    {

        if (Health <= 0)
        {
            SceneManager.LoadScene("Level 8");

        }

    }


}
