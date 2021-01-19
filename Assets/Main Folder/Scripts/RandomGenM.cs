using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomGenM : MonoBehaviour
{
    public GameObject Question;
    public GameObject Fake1;
    public GameObject Fake2;
    public GameObject Fake3;
    public GameObject realans;
   
    int x;
    int y;
    int a;
    int b;
    int ans;
    int ans2;
    int ans3;
    int ans4;
    public static int[] numbers = { -4, 0, 4 };
    int chosenNumber;
    public static int number;


    void Start()
    {
        x = Random.Range(0, 10);
        y = Random.Range(0, 10);
        chosenNumber = Random.Range(0, 3);
        number = numbers[chosenNumber];
      
        realans.transform.position = new Vector3(number, 3.55f, 39.3f);
    }
    void Update()
    {
        ans = x * y;
        ans2 = x * y + 5;
        ans3 = x * y - 5;
        ans4 = x * y - 6;
        Question.GetComponent<Text>().text = x + " * " + y;
        Fake1.GetComponent<Text>().text = ans2 + "";
        Fake2.GetComponent<Text>().text = ans3 + "";
        Fake3.GetComponent<Text>().text = ans4 + "";
        realans.GetComponent<Text>().text = ans + "";
    }
}
