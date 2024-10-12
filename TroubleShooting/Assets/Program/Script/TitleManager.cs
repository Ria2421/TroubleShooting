using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class TitleManager : BaseManager
{
    /// <summary>入力 ができるか</summary>
    private bool m_isInputStart = false;

    /// <summary> 入力待機時間 </summary>
    [SerializeField]
    private float m_waitInputTime;

    /// <summary>生成用プレハブ</summary>
    [SerializeField]
    private GameObject m_scoreManager;

    /// <summary>生成用プレハブ</summary>
    [SerializeField]
    private GameObject m_sceneManager;


    protected override void OnAwake()
    {
        if (GameObject.Find("ScoreManager") == null)
        {
            Instantiate(m_scoreManager).gameObject.name = "ScoreManager";
        }
        if (GameObject.Find("SceneManager") == null)
        {
            Instantiate(m_sceneManager).gameObject.name = "SceneManager";
        }
    }

    private void Start()
    {
        AddWaitTime(m_waitInputTime, OnStartInput);
    }

    protected override void OnUpdate()
    {
        if (m_isInputStart && Input.anyKey)
        {
            m_gameSceneManager.ChangeScene(SceneType.MainGame);
        }
    }

    /// <summary>
    /// 入力開始
    /// </summary>
    private void OnStartInput()
    {
        SetEnableInput(true);
    }

    /// <summary>
    /// 入力有効設定
    /// </summary>
    /// <param name="_enable"></param>
    public void SetEnableInput(bool _enable)
    {
        m_isInputStart = _enable;
    }

}
