using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitanim : MonoBehaviour
{
    private Animator anim;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    public GameObject target6;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(ExampleCoroutine());
        anim.Play("man down");

    }


    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(40);
            target1.SetActive(true);
            yield return new WaitForSeconds(10);
            anim.Play("360 hand");
            yield return new WaitForSeconds(10);
            anim.Play("swipe");
            target2.SetActive(true);
            yield return new WaitForSeconds(5);
            anim.Play("Mma kick");
            yield return new WaitForSeconds(5s);
            anim.Play("swing");
            yield return new WaitForSeconds(10);
            anim.Play("man down");


        }

        yield return null;

    }
}
