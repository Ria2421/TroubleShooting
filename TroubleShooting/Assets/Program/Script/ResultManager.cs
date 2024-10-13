using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static GameSceneManager;
using static ScoreManager;

public class ResultManager : BaseManager
{
    /// <summary>���� ���ł��邩</summary>
    private bool m_isInputStart = false;

    /// <summary> ���͑ҋ@���� </summary>
    [SerializeField]
    private float m_waitInputTime;

    [SerializeField]
    private TextMeshProUGUI m_scoreText;

    /// <summary> �X�R�A�}�l�[�W��</summary>
    private ScoreManager m_scoreManager;

    protected override void OnStart()
    {
        AddWaitTime(m_waitInputTime, OnStartInput);
        GameObject scoreObj = GameObject.Find("ScoreManager");

        if (scoreObj != null)
        {
            m_scoreManager = scoreObj.GetComponent<ScoreManager>();
            m_scoreText.text = m_scoreManager.GetScore().ToString();
        }
    }

    protected override void OnUpdate()
    {
        if (m_isInputStart && Input.anyKey)
        {
            m_gameSceneManager.ChangeScene(SceneType.Title);
            m_scoreManager.AddScoreData( m_scoreManager.GetScore() );
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
