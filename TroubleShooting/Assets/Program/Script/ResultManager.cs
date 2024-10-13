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

    [SerializeField]
    private TextMeshProUGUI m_1stText;

    [SerializeField]
    private TextMeshProUGUI m_2ndText;

    [SerializeField]
    private TextMeshProUGUI m_3rdText;

    [SerializeField]
    private TextMeshProUGUI m_4thText;

    [SerializeField]
    private TextMeshProUGUI m_5thText;

    /// <summary> �X�R�A�}�l�[�W��</summary>
    private ScoreManager m_scoreManager;

    protected override void OnStart()
    {
        AddWaitTime(m_waitInputTime, OnStartInput);
        GameObject scoreObj = GameObject.Find("ScoreManager");

        Debug.Log("hoge");

        if (scoreObj != null)
        {
            m_scoreManager = scoreObj.GetComponent<ScoreManager>();
            m_scoreText.text = m_scoreManager.GetScore().ToString();

            /*
            // �X�R�A�f�[�^���擾
            List<ScoreData> allScore = new List<ScoreData>();
            allScore = m_scoreManager.GetScoreData();
            Debug.Log("HOGE");

            // ���Ƃ��ăe�L�X�g��ύX
            m_1stText.text = allScore[0].score.ToString();
            m_2ndText.text = "2222222222";
            m_3rdText.text = "3333333333";
            m_4thText.text = "444";
            m_5thText.text = "55";
            */
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
