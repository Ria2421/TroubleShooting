using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private SceneType nextScene;

    public enum SceneType
    {
        Title,
        MainGame,
        Result
    }

    /// <summary>
    /// SceneˆÚ“®
    /// </summary>

    public void LoadChangeScene( SceneType type )
    {
        string sceneName = "";

        switch( type )
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
