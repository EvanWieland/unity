using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:Singleton<GameManager>
{
    public int score;

    private string currentLevelName = string.Empty;

    public GameObject pauseMenu;

    /*  #region This code makes this class a Singleton
      public static GameManager instance;

      private void Awake()
      {
          if(instance == null)
          {
              instance = this;
              DontDestroyOnLoad(gameObject);
          }
          else
          {
              Destroy(gameObject);
              Debug.LogError("Trying to int a second inst of GM.");
          }
      }
      #endregion*/

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currentLevelName);

        if (ao != null)
        {
            Debug.LogError("[GameManager] Unable to unload level" + currentLevelName);
            return;
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) Pause();
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

    /*public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        if(ao != null)
        {
            Debug.LogError("[GameManager] Unable to load level" + levelName);
            return;
        }

        currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);

        if (ao != null)
        {
            Debug.LogError("[GameManager] Unable to unload level" + levelName);
            return;
        }
    }*/

}
