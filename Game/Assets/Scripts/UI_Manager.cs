using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UI_Manager : MonoBehaviour
{
    [Header("UI")]
    public GameObject gameOver;
    public GameObject win;
    public CameraFollow cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        win.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            GameOver();
        }
    }

    public void WinGame()
    {
        cameraFollow.enabled = false; //Disable camera follow script
        win.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        cameraFollow.enabled = false; //Disable camera follow script
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(0); //Reload scene
        Time.timeScale = 0;
    }
}
