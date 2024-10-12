using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : BaseManager
{
    /// <summary> 現在のスコア</summary>
    private int m_currentScore;

    /// <summary>すべてのスコア</summary>
    private List<ScoreData> m_allScore;

    /// <summary>
    /// スコアデータ
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
    /// リザルト表示用スコア
    /// </summary>
    /// <param name="_addScore"></param>
    public void SetScore( int _addScore )
    {
        m_currentScore += _addScore;
    }

    /// <summary>
    /// スコアデータ登録
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
