using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class TitleManager : BaseManager
{
    /// <summary>���� ���ł��邩</summary>
    private bool m_isInputStart = false;

    /// <summary> ���͑ҋ@���� </summary>
    [SerializeField]
    private float m_waitInputTime;

    /// <summary>�����p�v���n�u</summary>
    [SerializeField]
    private GameObject m_scoreManager;

    /// <summary>�����p�v���n�u</summary>
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
    /// ���͊J�n
    /// </summary>
    private void OnStartInput()
    {
        SetEnableInput(true);
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
