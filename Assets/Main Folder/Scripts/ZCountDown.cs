using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZCountDown : MonoBehaviour
{
    public float timeLeft = 300;
    public Text startText;

    public GameObject Door;
    public GameObject DoorTrigger;
    public GameObject RoomLight;
    public GameObject DoorLight;
    public GameObject ButtonLight;
    public GameObject Stand;
    public GameObject Canvas;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = "CountDown \n" + (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            Door.SetActive(false);
            DoorTrigger.SetActive(true);
            RoomLight.SetActive(true);
            DoorLight.SetActive(true);
            ButtonLight.SetActive(false);
            Canvas.SetActive(false);
            Stand.SetActive(false);

        }
    }
}
