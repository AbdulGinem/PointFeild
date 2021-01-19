using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using BNG;

public class spawnobjs : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject myPrefab2;
    public GameObject myPrefab3;
    public GameObject myPrefab4;
     bool check = false;
     bool ncheck = false;
     bool scheck = true;
     bool lcheck = true;
     bool mcheck = false;

    void Start()
    {
        Instantiate(myPrefab);
        StartCoroutine(idk());
        StartCoroutine(ExampleCoroutine());
        StartCoroutine(ExampleCoroutine2());
        StartCoroutine(ExampleCoroutine3());
        StartCoroutine(ExampleCoroutine4());
        StartCoroutine(ExampleCoroutine5());
    }


    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            MoveToWaypoint.MovementSpeed += 1;
        }
        
    }

    IEnumerator ExampleCoroutine2()
    {
        while (true)
        {
            if (check == true)
            {
                yield return new WaitForSeconds(20);
                scheck = false;
                ncheck = true;
            }
            yield return null;
        }
    }

    IEnumerator ExampleCoroutine4()
    {
        while (true)
        {
            if (lcheck == true)
            {
                yield return new WaitForSeconds(30);
                mcheck = true;
                ncheck = false;

            }
            yield return null;
        }
    }

    IEnumerator ExampleCoroutine5()
    {
        while (true)
        {
            if (mcheck == true)
            {
                
                yield return new WaitForSeconds(5);
                Instantiate(myPrefab4);
                yield return new WaitForSeconds(5);

            }
            yield return null;
        }
    }

    IEnumerator ExampleCoroutine3()
    {
        while (true)
        {
            if (ncheck == true)
            {
                
                yield return new WaitForSeconds(5);
                Instantiate(myPrefab3);
                yield return new WaitForSeconds(5);

            }
            yield return null;
        }
    }

    public IEnumerator idk()
    {
        while (true)
        {

            if (bdown.yes == true & scheck == true)
            {
                check = true;
                yield return new WaitForSeconds(5);
                Instantiate(myPrefab2);
                yield return new WaitForSeconds(5);

            }
            yield return null;
        }
    }
}