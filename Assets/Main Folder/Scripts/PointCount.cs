using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PointCount : MonoBehaviour
{



    public static int scoreValue = 0;
    Text score;

   


    void Start()
    {
        scoreValue = 0;
        score = GetComponent<Text>();
     
    }
  


    void Update()
    {
        score.text = "Deaths: " + scoreValue;

    }



   




}
