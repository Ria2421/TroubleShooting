using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using KanKikuchi.AudioManager;
using static GameSceneManager;

public class GameManager : BaseManager
{
    /// <summary>　開示待機時間 </summary>
    [SerializeField]
    private float m_startGameWaitTime;

    /// <summary>終了後待機時間</summary>
    [SerializeField]
    private float m_finishGameWaitTime;

    /// <summary> 基本の加算スコア</summary>
    [SerializeField]
    private int m_defaultAddScore;

    /// <summary> スタートカウントテキスト</summary>
    [SerializeField]
    private GameObject m_startCountText;

    [SerializeField]
    private float addSecond = 0;

    /// <summary>コンボ数カウント</summary>
    private int m_comboCount;

    private int m_waitCount;

    /// <summary> UIマネージャ </summary>
    private MainGameUIManager m_uiManager;

    /// <summary> タイマーマネージャ</summary>
    private MainGameTimerManager m_timerManager;

    /// <summary> スコアマネージャ</summary>
    private ScoreManager m_scoreManager;

    private TextMeshProUGUI m_meshProUGUI;

    private Player m_player;

    private bool m_isFinish = false;

    protected override void OnAwake()
    {
        GameObject obj = GameObject.Find("UIManager");

        if (obj != null)
        {
            m_uiManager = obj.GetComponent<MainGameUIManager>();
            m_timerManager = obj.GetComponent<MainGameTimerManager>();
        }

        GameObject scoreObj = GameObject.Find("ScoreManager");

        if (scoreObj != null)
        {
            m_scoreManager = scoreObj.GetComponent<ScoreManager>();
        }

        m_meshProUGUI = GameObject.Find("CountText").GetComponent<TextMeshProUGUI>();
    }

    protected override void OnStart()
    {
        BGMManager.Instance.Play(BGMPath.MUS_MUS_BGM171,0.35f);

        m_player = GameObject.Find("Player").GetComponent<Player>();

        // TODO:競合対策　後で消す
        m_defaultAddScore = m_defaultAddScore == 0 ? 10 : m_defaultAddScore;

        m_meshProUGUI.text = (3).ToString();
        AddWaitTime(1.0f, OnEndTelopCount);
        m_player.cantMoveFlag = true;
        m_timerManager.cantCountFlag = true;

        //AddWaitTime(m_startGameWaitTime, OnEndStartGameWait);
    }

    protected override void OnUpdate()
    {
    }

    /// <summary>
    /// スコア加算
    /// </summary>
    public void AddScore()
    {
        m_comboCount++;

        if ( m_scoreManager != null )
        {
            //暫定加算
            m_uiManager.SetScoreText(m_defaultAddScore * m_comboCount) ;
            m_uiManager.ChangeComboText(m_comboCount);

            if (m_comboCount % 10 == 0)
            {
                m_timerManager.addPlayTime(addSecond);
            }
        }
    }

    /// <summary>
    /// スコア減算
    /// </summary>
    public void SubtractScore()
    {
        m_comboCount = 0;

        if (m_scoreManager != null)
        {
            //m_uiManager.m_nTestCnt -= 10;
            m_uiManager.ChangeComboText(m_comboCount);
        }
    }

    /// <summary>
    /// メインゲーム終了コールバック
    /// </summary>
    public void FinishMainGame()
    {
        if (!m_isFinish)
        {
            if (m_scoreManager != null)
            {
                m_scoreManager.SetScore(m_uiManager.m_nTestCnt);
            }

            m_isFinish = true;
            AddWaitTime(m_finishGameWaitTime, OnEndFinishGameWait, true);
        }
    }

    /// <summary>
    /// ゲーム終了待機処理
    /// </summary>
    private void OnEndFinishGameWait()
    {
            Debug.Log("おわり");
        if (m_scoreManager != null)
        {
            m_gameSceneManager.ChangeScene(SceneType.Result);
        }
    }

    /// <summary>
    /// ゲーム開始待機処理
    /// </summary>
    private void OnEndStartGameWait()
    {

    }


    /// <summary>
    /// ゲーム開始待機処理
    /// </summary>
    private void OnEndTelopCount()
    {
        m_waitCount++;
        m_meshProUGUI.text = ( 3 - m_waitCount ).ToString();

        if (m_waitCount < m_startGameWaitTime)
        {
            AddWaitTime(1.0f, OnEndTelopCount, true);
        }
        else
        {
            m_meshProUGUI.gameObject.SetActive( false );
            m_player.cantMoveFlag = false;
            m_timerManager.cantCountFlag = false;
        }
    }
}
