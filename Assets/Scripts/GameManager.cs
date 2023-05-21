using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("APERTOU O ENTER.");
            
            SceneManager.LoadScene("01");
        }
        //mobile input enter for start game
        if (Input.touchCount > 0)
        {
            Debug.Log("APERTOU O ENTER.");
            SceneManager.LoadScene("01");
        }
        
    }
}
