using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public GameObject obj;
    public Image[] images;
    public Sprite[] sprites;
    private int currentIndex = 0;
    private static bool canChange = true;
    public static bool done = false;
    private int nextSceneToLoad;



    private void Start()

    {

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

    }









    void ResetTimer()
    {
        canChange = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand" && canChange)
        {

            canChange = false;
            currentIndex++;
            if (currentIndex >= sprites.Length)
                currentIndex = 0;
            obj.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[currentIndex];
            Invoke("ResetTimer", 3f);
        }


        if (currentIndex >= 4)
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nextSceneToLoad);

        }

    }
}
