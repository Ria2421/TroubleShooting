using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static ScoreManager;

public class ScoreManager : BaseManager
{
    //改行コード
    private const string SPRIT_TEXT = "\n\r";

    //セーブフォルダ名
    private const string FOLDER_NAME = "SaveData.json";

    /// <summary> 現在のスコア</summary>
    private int m_currentScore;

    /// <summary>すべてのスコア</summary>
    [SerializeField]
    public List<ScoreData> m_allScore;

    /// <summary> 保存ファイルパス</summary>
    private string m_saveFilePath;

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
        m_saveFilePath = Application.persistentDataPath + "/" + FOLDER_NAME;
        Debug.Log(m_saveFilePath);
    }

    /// <summary>
    /// リザルト表示用スコア
    /// </summary>
    /// <param name="_addScore"></param>
    public void SetScore( int _addScore )
    {
        m_currentScore = _addScore;
    }

    /// <summary>スコア取得</summary>
    /// <returns>現在のスコア</returns>
    public int GetScore() 
    {
        return m_currentScore;
    }

    /// <summary>
    /// スコアデータ登録
    /// </summary>
    /// <param name="score"></param>
    /// <param name="useName"></param>
    public void AddScoreData( int _score ) 
    {
        ScoreData data = new ScoreData();

        data.score = _score;
        //data.userName = _useName;
        m_allScore.Add(data);
        SaveScore(data);
    }

    /// <summary>
    /// ランキングスコア読み込み
    /// </summary>
    public void LoadSaveData()
    {
        if ( File.Exists( m_saveFilePath ) )
        {
            StreamReader reader = new StreamReader(m_saveFilePath);
            string scoreData = reader.ReadToEnd();
            // 改行毎に切り分け
            string[] rankingList = scoreData.Split(SPRIT_TEXT);
            foreach ( string ranking in rankingList ) 
            {
                m_allScore.Add(JsonUtility.FromJson<ScoreData>(ranking));
            }

            reader.Close();
        }
    }

    /// <summary>
    /// スコア追加保存
    /// </summary>
    /// <param name="_data"></param>
    public void SaveScore(ScoreData _data)
    {
        string scoreData = "";
        foreach ( ScoreData data in m_allScore ) 
        {
            scoreData += JsonUtility.ToJson(data);
            scoreData += SPRIT_TEXT;

        }
        scoreData += JsonUtility.ToJson(_data);
        scoreData += SPRIT_TEXT;

        StreamWriter writer = new StreamWriter(m_saveFilePath, false);
        writer.WriteLine(scoreData);
        writer.Close();
    }

    /// <summary>
    /// スコア全消去
    /// </summary>
    /// <param name="_data"></param>
    public void DestorySaveData()
    {
        StreamWriter writer = new StreamWriter(m_saveFilePath, false);
        writer.WriteLine("");
        writer.Close();
    }

}
