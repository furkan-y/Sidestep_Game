using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject Stop_Menu;
    public GameObject Lost_Menu;
    public GameObject Credits;
    public TMPro.TextMeshProUGUI CountDownTMP;
    public TMPro.TextMeshProUGUI ShowStageTMP;

    public GameObject VerticalWall;
    public GameObject HorizontalWall;

    public AudioSource GameoverSound;
    public AudioSource BGM;
    public AudioSource ButtonClickedSound;


    public void StartEndlessBtn()
    {
        ButtonClickedSound.Play();
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;

    }

    public void BackToMainMenuBtn()
    {
        ButtonClickedSound.Play();
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Lost_Menu.SetActive(true);
        BGM.Stop();
        GameoverSound.Play();
        Time.timeScale = 0f;
    }

    public void StopBtn()
    {
        Debug.Log("Stop BTN Çalýþtý");
        ButtonClickedSound.Play();
        Stop_Menu.SetActive(true);
        CountDownTMP.text = "";
        ShowStageTMP.text = "";
        Time.timeScale = 0f;
    }

    public void ContinueBtn()
    {
        ButtonClickedSound.Play();
        Time.timeScale = 1f;
        Stop_Menu.SetActive(false);

        Lost_Menu.SetActive(false);
    }

    public void LevelLoaderBtn(int level)
    {
        SceneManager.LoadScene(level + 2);
    }

    public void CreditsBtn()
    {
        Credits.SetActive(true);
    }

    public void ToMenuFromCredits()
    {
        Credits.SetActive(false);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }


}
