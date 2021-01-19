using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zwave : MonoBehaviour
{
    bool swave = false;
    public GameObject B1;
    public GameObject D1;
    public GameObject F1;
    public GameObject H1;

    public GameObject B2;
    public GameObject D2;
    public GameObject F2;
    public GameObject H2;

    public GameObject B3;
    public GameObject D3;
    public GameObject F3;
    public GameObject H3;

    public GameObject B4;
    public GameObject D4;
    public GameObject F4;
    public GameObject H4;



    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    public void bdo()
    {

        swave = true;
    
    }

   

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {

            if (swave == true)
            {
                yield return new WaitForSeconds(20);
                B1.transform.position = new Vector3(0, 0, 0);
                D1.transform.position = new Vector3(0, 0, 0);
                F1.transform.position = new Vector3(0, 0, 0);
                H1.transform.position = new Vector3(0, 0, 0);
                yield return new WaitForSeconds(20);
                B2.transform.position = new Vector3(0, 0, 0);
                D2.transform.position = new Vector3(0, 0, 0);
                F2.transform.position = new Vector3(0, 0, 0);
                H2.transform.position = new Vector3(0, 0, 0);
                yield return new WaitForSeconds(20);
                B3.transform.position = new Vector3(0, 0, 0);
                D3.transform.position = new Vector3(0, 0, 0);
                F3.transform.position = new Vector3(0, 0, 0);
                H3.transform.position = new Vector3(0, 0, 0);
                yield return new WaitForSeconds(20);
                B4.transform.position = new Vector3(0, 0, 0);
                D4.transform.position = new Vector3(0, 0, 0);
                F4.transform.position = new Vector3(0, 0, 0);
                H4.transform.position = new Vector3(0, 0, 0);
            }
            yield return null;
        }

        
    }

  
}
