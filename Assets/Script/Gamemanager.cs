using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    
    public GameObject menuSet;
    public GameObject ExitSet;
    public AudioSource s;
    public GameObject CookEnemeyManager;

    private void Start()
    {
        s.Play();
        StartCoroutine(ManagerOn());
    }
    private IEnumerator ManagerOn()
    {
        yield return new WaitForSeconds(2f);
        CookEnemeyManager.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (ExitSet.activeSelf)
            {
                s.Play();
                Time.timeScale = 1f;
                ExitSet.SetActive(false);
            }
            else
            {
                s.Stop();
                Time.timeScale = 0f;
                ExitSet.SetActive(true);
            }
        }
    }
    public void ExitSetOn()
    {
        if (ExitSet.activeSelf)
        {
            menuSet.SetActive(true);
            ExitSet.SetActive(false);
        }
        else
        {
            ExitSet.SetActive(true);
            menuSet.SetActive(false);
        }
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void MenuOn()
    {
        if (menuSet.activeSelf)
        {
            s.Play();
            Time.timeScale = 1f;
            menuSet.SetActive(false);
        }
        else
        {
            s.Stop();
            Time.timeScale = 0f;
            menuSet.SetActive(true);
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Num1.score = 0;
        Num2.score = 0;
        Num3.score = 0;
        Num4.score = 0;
        Num5.score = 0;
        Score.score = 0;
        SceneManager.LoadScene("PlayScene");
    }


}
