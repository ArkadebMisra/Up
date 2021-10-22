using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Home();
        if(Input.touchCount > 0)
        {
            StartGame();
        }
        
        
    }

    void Home()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void StartGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
