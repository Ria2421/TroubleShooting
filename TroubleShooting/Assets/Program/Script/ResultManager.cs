using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class ResultManager : BaseManager
{
    /// <summary>���� ���ł��邩</summary>
    private bool m_isInputStart = false;

    /// <summary> ���͑ҋ@���� </summary>
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
    /// ���͊J�n
    /// </summary>
    private void OnStartInput()
    {
        SetEnableInput( true );
    }

    /// <summary>
    /// ���͗L���ݒ�
    /// </summary>
    /// <param name="_enable"></param>
    public void SetEnableInput(bool _enable)
    { 
        m_isInputStart = _enable;
    }
    
}
