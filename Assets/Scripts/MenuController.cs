using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private GameObject scoreBoard;
    private GameObject startButton;
    private GameObject exitButton;
    private float timer = 0;
    public bool mainmenu = false;


    void Start()
    {
        if (mainmenu == false)
        {
            scoreBoard = transform.Find("Score").gameObject;
            startButton = transform.Find("StartButton").gameObject;
            exitButton = transform.Find("ExitButton").gameObject;
            scoreBoard.SetActive(false);
            startButton.SetActive(false);
            exitButton.SetActive(false);
            timer = 0;
        }
    }

    void Update()
    {
        if (mainmenu == false)
        {
            timer += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void StopGame()
    {
        scoreBoard.SetActive(true);
        startButton.SetActive(true);
        exitButton.SetActive(true);
        Time.timeScale = 0;
        scoreBoard.GetComponent<Text>().text = "You Survived For: " + Mathf.Round(timer) + " Seconds!";
    }

    void RestartGame()
    {
        if (mainmenu == false)
        {
            scoreBoard.SetActive(false);
            startButton.SetActive(false);
            exitButton.SetActive(false);
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("Map1");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
