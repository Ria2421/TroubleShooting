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
    // �����L���O�e�L�X�g�I�u�W�F�N�g�p
    private GameObject m_1stTextObj;
    private GameObject m_2ndTextObj;
    private GameObject m_3rdTextObj;
    private GameObject m_4thTextObj;
    private GameObject m_5thTextObj;
    
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
       // �����L���O�\���̕ύX
       ChangeRankingText();

        return m_currentScore;
    }

    // �����L���O�\���̕ύX
    public void ChangeRankingText()
    {
        // �f�[�^�̓ǂݍ���
        LoadSaveData();

        // �����L���O�p�e�L�X�g�I�u�W�F�N�g���擾
		m_1stTextObj = GameObject.Find("1st");
		m_2ndTextObj = GameObject.Find("2nd");
		m_3rdTextObj = GameObject.Find("3rd");
		m_4thTextObj = GameObject.Find("4th");
		m_5thTextObj = GameObject.Find("5th");

        /*
        // �������p��
        string Str = "0";

        // �f�[�^�����݂����
        if (m_allScore.Count != 0)
        {       
            Str = m_allScore[0].score.ToString;
        }
        */

        // �����L���O�̐��l�𔽉f
        m_1stTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 0 ? "0" : m_allScore[0].score.ToString();
        m_2ndTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 1 ? "0" : m_allScore[1].score.ToString();
        m_3rdTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 2 ? "0" : m_allScore[2].score.ToString();
        m_4thTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 3 ? "0" : m_allScore[3].score.ToString();
        m_5thTextObj.GetComponent<TextMeshProUGUI>().text = m_allScore.Count <= 4 ? "0" : m_allScore[4].score.ToString();
    }

    /*// �S�f�[�^���擾
    public List<ScoreData> GetScoreData()
    {
        return m_allScore;
    }*/

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
                //m_allScore.Add(JsonUtility.FromJson<ScoreData>(ranking));
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
        // �X�R�A�l�̃\�[�g
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
    /// �X�R�A�S����
    /// </summary>
    /// <param name="_data"></param>
    public void DestorySaveData()
    {
        StreamWriter writer = new StreamWriter(m_saveFilePath, false);
        writer.WriteLine("");
        writer.Close();
    }

    // �X�R�A�l�̃\�[�g����
    public void SortScore()
    {
       m_allScore.Sort((a, b) => b.score - a.score);    // ����
       //m_allScore.Sort((a, b) => a.score - b.score);  // �~��
       
       for(int i = 0; i < m_allScore.Count; i++)
       {
           Debug.Log(i.ToString() +"�l��");
           Debug.Log(m_allScore[i].score);
           Debug.Log(m_allScore[i].userName);
       }
    }
}
