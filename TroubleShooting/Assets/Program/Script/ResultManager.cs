using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class ResultManager : BaseManager
{
    /// <summary>入力 ができるか</summary>
    private bool m_isInputStart = false;

    /// <summary> 入力待機時間 </summary>
    [SerializeField]
    private float m_waitInputTime;

    protected override void OnStart()
    {
        AddWaitTime(m_waitInputTime, OnStartInput);
    }

    protected override void OnUpdate()
    {
        if (m_isInputStart && Input.anyKey)
        {
            m_gameSceneManager.ChangeScene(SceneType.Title);
        }
    }

    /// <summary>
    /// 入力開始
    /// </summary>
    private void OnStartInput()
    {
        SetEnableInput( true );
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
