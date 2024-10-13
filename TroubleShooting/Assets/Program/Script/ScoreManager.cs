using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static ScoreManager;

public class ScoreManager : BaseManager
{
    // ランキングテキストオブジェクト用
    private GameObject m_1stTextObj;
    private GameObject m_2ndTextObj;
    private GameObject m_3rdTextObj;
    private GameObject m_4thTextObj;
    private GameObject m_5thTextObj;
    
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
    public struct ScoreData
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
       // ランキング表示の変更
       ChangeRankingText();

        return m_currentScore;
    }

    // ランキング表示の変更
    public void ChangeRankingText()
    {
        // データの読み込み
        LoadSaveData();

        // ランキング用テキストオブジェクトを取得
		m_1stTextObj = GameObject.Find("1st");
		m_2ndTextObj = GameObject.Find("2nd");
		m_3rdTextObj = GameObject.Find("3rd");
		m_4thTextObj = GameObject.Find("4th");
		m_5thTextObj = GameObject.Find("5th");

        /*
        // 文字列を用意
        string Str = "0";

        // データが存在すれば
        if (m_allScore.Count != 0)
        {       
            Str = m_allScore[0].score.ToString;
        }
        */

        // ランキングの数値を反映
        m_1stTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 0 ? "0" : m_allScore[0].score.ToString();
        m_2ndTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 1 ? "0" : m_allScore[1].score.ToString();
        m_3rdTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 2 ? "0" : m_allScore[2].score.ToString();
        m_4thTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 3 ? "0" : m_allScore[3].score.ToString();
        m_5thTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 4 ? "0" : m_allScore[4].score.ToString();
    }

    /*// 全データを取得
    public List<ScoreData> GetScoreData()
    {
        return m_allScore;
    }*/

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
                //m_allScore.Add(JsonUtility.FromJson<ScoreData>(ranking));
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
        // スコア値のソート
        SortScore();

        string scoreData = "";
        foreach ( ScoreData data in m_allScore ) 
        {
            scoreData += JsonUtility.ToJson(data);
            //scoreData += SPRIT_TEXT;
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

    // スコア値のソート処理
    public void SortScore()
    {
       m_allScore.Sort((a, b) => b.score - a.score);    // 昇順
       //m_allScore.Sort((a, b) => a.score - b.score);  // 降順
       
       for(int i = 0; i < m_allScore.Count; i++)
       {
           Debug.Log(i.ToString() +"人目");
           Debug.Log(m_allScore[i].score);
           Debug.Log(m_allScore[i].userName);
       }
    }
}
