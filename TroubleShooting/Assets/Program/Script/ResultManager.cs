using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static GameSceneManager;
using static ScoreManager;

public class ResultManager : BaseManager
{
    /// <summary>入力 ができるか</summary>
    private bool m_isInputStart = false;

    /// <summary> 入力待機時間 </summary>
    [SerializeField]
    private float m_waitInputTime;

    [SerializeField]
    private TextMeshProUGUI m_scoreText;

    /// <summary> スコアマネージャ</summary>
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
