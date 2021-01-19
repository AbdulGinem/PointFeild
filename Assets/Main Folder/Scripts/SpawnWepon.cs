using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWepon : MonoBehaviour
{

    public GameObject weapon;
    public GameObject Ammow;
    public GameObject B;
    public GameObject D;
    public GameObject F;
    public GameObject H;
    

    public void spawnwep()
    {
            Instantiate(weapon);
    }

    public void spawnAMO()
    {

        Instantiate(Ammow);
        Instantiate(Ammow);
        
    }
    public void spawnZombie()
    {

        B.transform.position = new Vector3(0, 0, 0);
        D.transform.position = new Vector3(0, 0, 0);
        F.transform.position = new Vector3(0, 0, 0);
        H.transform.position = new Vector3(0, 0, 0);
        

    }



}
