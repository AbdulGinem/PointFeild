using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

  
    private int nextSceneToLoad;

    private void Start()

    {
 
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
     
    }

    



    void OnTriggerEnter(Collider col)
    {
        

        if (col.gameObject.tag == "Hand")
        {




            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nextSceneToLoad);




        }

    }


}
