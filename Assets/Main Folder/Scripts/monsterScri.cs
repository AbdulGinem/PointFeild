using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterScri : MonoBehaviour
{
    public GameObject boss;
    bool monster = true;


    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {

            if (monster == true)
            {
                yield return new WaitForSeconds(5);
                boss.GetComponent<Animator>().Play("New Animation");
                yield return new WaitForSeconds(3);
                boss.GetComponent<Animator>().Play("Gdpunch");
                yield return new WaitForSeconds(3);
                boss.GetComponent<Animator>().Play("copytest");
                yield return new WaitForSeconds(5);
                boss.GetComponent<Animator>().Play("myAnim");


            }
            yield return null;
        }



        
    }
}
