using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public enum SceneType
    { 
        Title,
        MainGame,
        Result
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void ChangeScene( SceneType _type )
    {

        string sceneName = "";

        switch (_type)
        {
            case SceneType.Title:
                {
                    sceneName = "Title";
                }
                break;
            case SceneType.MainGame:
                {
                    sceneName = "MainGame";
                }
                break;
            case SceneType.Result:
                {
                    sceneName = "Result";
                }
                break;

        }
        SceneManager.LoadScene(sceneName);
    }
}