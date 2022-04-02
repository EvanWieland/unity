/*
 * Evan Wieland
 * Assignment 6
 * 
 * Manage game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:Singleton<GameManager>
{
    public int score;

    private string currentLevelName = string.Empty;

    public GameObject pauseMenu;

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void UnloadCurrentLevel()
    {
        SceneManager.UnloadScene(currentLevelName);
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !Goal.died) Pause();
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);

        Unpause();

        currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        bool ao = SceneManager.UnloadScene(levelName);

        if (ao == false)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }
    }

}
