using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targets : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public float sX;
    public float sY;
    public float sZ;
    public float s2X;
    public float s2Y;
    public float s2Z;
    public Transform mPosition;
    public float rX;
    public float rY;
    public float rZ;
    public Transform mPosition2;
    public float rX2;
    public float rY2;
    public float rZ2;
    public float moveSpeed;
    public float rotateSpeed;
    public int targetGoal;
    public static int targetValue = 0;
   
   



    Text targetss;

    void Start()
    {
        targetValue = 0;
        targetss = GetComponent<Text>();

        if (obj3 != null) 
        { 
        obj3.GetComponent<BoxCollider>().enabled = true;
        obj3.GetComponent<SpriteRenderer>().enabled = true;
        }

    }



    void Update()
    {

        

        if (targetValue >= targetGoal)
        {

            if (obj3 != null)
             
            {
                obj3.GetComponent<BoxCollider>().enabled = false;
                obj3.GetComponent<SpriteRenderer>().enabled = false;
            }

            Vector3 rotationVector = new Vector3(rX, rY, rZ);
            Vector3 rotationVector2 = new Vector3(rX2, rY2, rZ2);
            Quaternion rotation1 = Quaternion.Euler(rotationVector);
            Quaternion rotation2 = Quaternion.Euler(rotationVector2);
            float step = moveSpeed * Time.deltaTime;

            if (obj1 != null)
            {
                obj1.transform.rotation = Quaternion.Slerp(obj1.transform.rotation, rotation1, Time.deltaTime * rotateSpeed);
                obj1.transform.position = Vector3.MoveTowards(obj1.transform.position, mPosition.position, step);
            }

            if (obj2 != null)
            {
                obj2.transform.rotation = Quaternion.Slerp(obj2.transform.rotation, rotation2, Time.deltaTime * rotateSpeed);
                obj2.transform.position = Vector3.MoveTowards(obj2.transform.position, mPosition2.position, step);
            }
        }

        else
        {
            if (obj3 != null)
            {
                obj3.GetComponent<BoxCollider>().enabled = true;
                obj3.GetComponent<SpriteRenderer>().enabled = true;
            }


            if (obj1 != null)
            {
                obj1.transform.position = new Vector3(sX, sY, sZ);
                obj1.transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (obj2 != null)
            {
                obj2.transform.position = new Vector3(s2X, s2Y, s2Z);
                obj2.transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            

        }
    }



}
