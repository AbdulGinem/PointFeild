using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public float timeLeft = 300;
    public Text startText;

   
    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = "CountDown \n"  + (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
