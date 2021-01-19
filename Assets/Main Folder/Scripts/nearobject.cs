using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearobject : MonoBehaviour
{
    public Transform Character; // Target Object to follow
    public float speed = 0.1F; // Enemy speed
    private Vector3 directionOfCharacter;
    static public bool challenged = false;// If the enemy is Challenged to follow by the player
    static public bool fast = false;


    void Start()
    {

        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {

        while (true)
        {
            if (fast == true) 
            {
                yield return new WaitForSeconds(10);
                speed += 0.001f;
                

            }
            yield return null;
        }
        
    }








    void Update()
    {

        if (challenged)
        {
            
            directionOfCharacter = Character.transform.position - transform.position;
            directionOfCharacter = directionOfCharacter.normalized;    // Get Direction to Move Towards
            transform.Translate(directionOfCharacter * speed, Space.World);
        }


    }
    // Will be triggered as soon as player would touch the Enemy Object
  
}
