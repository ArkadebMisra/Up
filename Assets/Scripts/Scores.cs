using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    public long hight = 0;
    public float timeSpent;
    public float increaseHightTime;
    public PlayerController player;
    public Text hightText;
    public GameOverScript gameOver;



    // Start is called before the first frame update
    void Start()
    {
        hightText.text = "Hight : " + 0;
        player = FindObjectOfType<PlayerController>();
        gameOver = FindObjectOfType<GameOverScript>();
        gameOver.HideOverScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseHightTime < 0)
        {
            hight += 1;
            if(player.hitObstacle == true)
            {
                player.hitObstacle = false;
                gameOver.GameOver(hight);
                hight = 0;
                //Invoke("Restart", 2f);

            }
            increaseHightTime = timeSpent;
        }
        else
        {
            increaseHightTime -= Time.deltaTime;
        }
        hightText.text = "Hight : " + hight;
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
