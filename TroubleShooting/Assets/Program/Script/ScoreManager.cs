using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : BaseManager
{
    /// <summary> ���݂̃X�R�A</summary>
    private int m_currentScore;

    /// <summary>���ׂẴX�R�A</summary>
    private List<ScoreData> m_allScore;

    /// <summary>
    /// �X�R�A�f�[�^
    /// </summary>
    public class ScoreData
    { 
        public int    score;
        public string userName;
    }

    protected override void OnAwake()
    {
        DontDestroyOnLoad(this);
        m_allScore = new List<ScoreData>(100);
    }

    /// <summary>
    /// ���U���g�\���p�X�R�A
    /// </summary>
    /// <param name="_addScore"></param>
    public void SetScore( int _addScore )
    {
        m_currentScore += _addScore;
    }

    /// <summary>
    /// �X�R�A�f�[�^�o�^
    /// </summary>
    /// <param name="score"></param>
    /// <param name="useName"></param>
    public void AddScoreData( int score, string useName ) 
    {
        ScoreData data = new ScoreData();

        data.score = score;
        data.userName = useName;
        m_allScore.Add(data);
    }


}
