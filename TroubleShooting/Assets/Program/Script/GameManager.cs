using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameSceneManager;

public class GameManager : BaseManager
{
    /// <summary>　開示待機時間 </summary>
    // [SerializeField]
    private float m_startGameWaitTime;

    /// <summary>終了後待機時間</summary>
    [SerializeField]
    private float m_finishGameWaitTime;

    /// <summary> UIマネージャ </summary>
    private MainGameUIManager m_uiManager;

    /// <summary> タイマーマネージャ</summary>
    private MainGameTimerManager m_timerManager;

    /// <summary> スコアマネージャ</summary>
    private ScoreManager m_scoreManager;

    protected override void OnAwake()
    {
        GameObject obj = GameObject.Find("UIManager");
        m_uiManager    = obj.GetComponent<MainGameUIManager>();
        m_timerManager = obj.GetComponent<MainGameTimerManager>();
        m_scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    protected override void OnStart()
    {
        AddWaitTime(m_startGameWaitTime, OnEndStartGameWait);
    }

    protected override void OnUpdate()
    {
    }

    /// <summary>
    /// スコア加算
    /// </summary>
    public void AddScore()
    {
        //暫定加算
        m_uiManager.m_nTestCnt += 10;
    }

    /// <summary>
    /// スコア減算
    /// </summary>
    public void SubtractScore()
    {
        m_uiManager.m_nTestCnt -= 10;
    }

    /// <summary>
    /// メインゲーム終了コールバック
    /// </summary>
    public void FinishMainGame()
    {
        m_scoreManager.SetScore( m_uiManager.m_nTestCnt );
        AddWaitTime(m_startGameWaitTime, OnEndFinishGameWait);
    }

    /// <summary>
    /// ゲーム終了待機処理
    /// </summary>
    private void OnEndFinishGameWait()
    {
        m_gameSceneManager.ChangeScene(SceneType.Result);
    }

    /// <summary>
    /// ゲーム開始待機処理
    /// </summary>
    private void OnEndStartGameWait()
    { 
    
    }
}
