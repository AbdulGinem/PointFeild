using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathCount : MonoBehaviour
{


    public static int deathValue = 0;
    public static int score = 0;
    Text death;




    void Start()
    {
        deathValue = 0;
        score = 1;
        death = GetComponent<Text>();
    }



    void Update()
    {
        death.text = "Deaths: " + deathValue;

        if (score >= 10)

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (score <= 0)

        {
            SceneManager.LoadScene("Level 7");
        }

    }

}
