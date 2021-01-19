using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDestroy : MonoBehaviour
{
    public GameObject obj;

    public int targetGoal;
    public int targetValue = 0;

    void Start()
    {
        targetValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetValue >= targetGoal)
        {

            obj.SetActive(false);

        }
        else
        {

            obj.SetActive(true);

        }
    }
}
