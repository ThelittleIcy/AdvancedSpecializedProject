using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { get => _instance; }
    private static ScenesManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void LoadScenes(string _name)
    {
        SceneManager.LoadScene(_name);
    }

    public void LoadWin()
    {
        LoadScenes("WinMenu");
    }

    public void LoadLose()
    {
        LoadScenes("LoseMenu");
    }
    public void LoadMenu()
    {
        LoadScenes("MainMenu");
    }
    public void LoadGame()
    {
        LoadScenes("GameScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
