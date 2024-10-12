using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static ScoreManager;

public class ScoreManager : BaseManager
{
    //���s�R�[�h
    private const string SPRIT_TEXT = "\n\r";

    //�Z�[�u�t�H���_��
    private const string FOLDER_NAME = "SaveData.json";

    /// <summary> ���݂̃X�R�A</summary>
    private int m_currentScore;

    /// <summary>���ׂẴX�R�A</summary>
    [SerializeField]
    public List<ScoreData> m_allScore;

    /// <summary> �ۑ��t�@�C���p�X</summary>
    private string m_saveFilePath;

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
        m_saveFilePath = Application.persistentDataPath + "/" + FOLDER_NAME;
        Debug.Log(m_saveFilePath);
    }

    /// <summary>
    /// ���U���g�\���p�X�R�A
    /// </summary>
    /// <param name="_addScore"></param>
    public void SetScore( int _addScore )
    {
        m_currentScore = _addScore;
    }

    /// <summary>�X�R�A�擾</summary>
    /// <returns>���݂̃X�R�A</returns>
    public int GetScore() 
    {
        return m_currentScore;
    }

    /// <summary>
    /// �X�R�A�f�[�^�o�^
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
    /// �����L���O�X�R�A�ǂݍ���
    /// </summary>
    public void LoadSaveData()
    {
        if ( File.Exists( m_saveFilePath ) )
        {
            StreamReader reader = new StreamReader(m_saveFilePath);
            string scoreData = reader.ReadToEnd();
            // ���s���ɐ؂蕪��
            string[] rankingList = scoreData.Split(SPRIT_TEXT);
            foreach ( string ranking in rankingList ) 
            {
                m_allScore.Add(JsonUtility.FromJson<ScoreData>(ranking));
            }

            reader.Close();
        }
    }

    /// <summary>
    /// �X�R�A�ǉ��ۑ�
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
    /// �X�R�A�S����
    /// </summary>
    /// <param name="_data"></param>
    public void DestorySaveData()
    {
        StreamWriter writer = new StreamWriter(m_saveFilePath, false);
        writer.WriteLine("");
        writer.Close();
    }

}
