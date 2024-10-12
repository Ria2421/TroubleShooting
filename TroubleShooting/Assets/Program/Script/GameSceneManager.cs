using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : BaseManager
{
    private SceneType m_currentSceneType;

    public enum SceneType
    { 
        Title,
        MainGame,
        Result
    }

    protected override void OnAwake()
    {
        DontDestroyOnLoad(this);
    }

    protected override void OnUpdate()
    {
    }

    public void ChangeScene( SceneType _type )
    {

        string sceneName = "";
        m_currentSceneType = _type;

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

    public SceneType GetCurrentSceneType()
    {
        return m_currentSceneType;
    }
}