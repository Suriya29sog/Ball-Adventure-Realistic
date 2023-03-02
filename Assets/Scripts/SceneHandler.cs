using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static bool IsPauseSceneLoad { get; private set; }
    public static bool IsSettingSceneLoad { get; private set;}

    public void OnStartButtonClick()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void OnSettingButtonClick()
    {
        if (!IsSettingSceneLoad)
        {
            IsSettingSceneLoad = true;
            SceneManager.LoadSceneAsync("SettingScene", LoadSceneMode.Additive);
        }

    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnPauseButtonClick()
    {
        if (!IsPauseSceneLoad)
        {
            IsPauseSceneLoad = true;
            SceneManager.LoadSceneAsync("PauseScene", LoadSceneMode.Additive);
        }

    }

    public void OnMainMenuButtonClick()
    {
        if (SceneManager.GetSceneByName("PauseScene").isLoaded)
            UnloadScene("PauseScene");
        SceneManager.LoadSceneAsync("MainMenu");

    }

    public void UnloadScene(string sceneName)
    {
        if (sceneName == "SettingScene")
            IsSettingSceneLoad = false;
        else if (sceneName == "PauseScene")
            IsPauseSceneLoad = false;

            SceneManager.UnloadSceneAsync(sceneName);

    }



}
