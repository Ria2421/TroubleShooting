using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameSceneManager;

public class GameManager : BaseManager
{
    /// <summary>�@�J���ҋ@���� </summary>
    // [SerializeField]
    private float m_startGameWaitTime;

    /// <summary>�I����ҋ@����</summary>
    [SerializeField]
    private float m_finishGameWaitTime;

    /// <summary> UI�}�l�[�W�� </summary>
    private MainGameUIManager m_uiManager;

    /// <summary> �^�C�}�[�}�l�[�W��</summary>
    private MainGameTimerManager m_timerManager;

    /// <summary> �X�R�A�}�l�[�W��</summary>
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
    /// �X�R�A���Z
    /// </summary>
    public void AddScore()
    {
        //�b����Z
        m_uiManager.m_nTestCnt += 10;
    }

    /// <summary>
    /// �X�R�A���Z
    /// </summary>
    public void SubtractScore()
    {
        m_uiManager.m_nTestCnt -= 10;
    }

    /// <summary>
    /// ���C���Q�[���I���R�[���o�b�N
    /// </summary>
    public void FinishMainGame()
    {
        m_scoreManager.SetScore( m_uiManager.m_nTestCnt );
        AddWaitTime(m_startGameWaitTime, OnEndFinishGameWait);
    }

    /// <summary>
    /// �Q�[���I���ҋ@����
    /// </summary>
    private void OnEndFinishGameWait()
    {
        m_gameSceneManager.ChangeScene(SceneType.Result);
    }

    /// <summary>
    /// �Q�[���J�n�ҋ@����
    /// </summary>
    private void OnEndStartGameWait()
    { 
    
    }
}
