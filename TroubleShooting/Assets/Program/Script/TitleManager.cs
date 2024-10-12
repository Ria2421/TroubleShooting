using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class TitleManager : MonoBehaviour
{
    private GameSceneManager m_gameSceneManager;


    // Start is called before the first frame update
    void Start()
    {
        m_gameSceneManager= GameObject.Find( "SceneManager" ).GetComponent<GameSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            m_gameSceneManager.ChangeScene(SceneType.MainGame);
        }
    }
}
