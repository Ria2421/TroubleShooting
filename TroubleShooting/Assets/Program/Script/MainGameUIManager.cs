using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameUIManager : MonoBehaviour
{
	GameObject m_ScoreTextObj = null;	// スコア用テキストオブジェクトを格納
	GameObject m_ComboTextObj = null;	// コンボ用テキストオブジェクトを格納
	public int m_nTestCnt = 0;			// テスト用のカウント
	int m_nMaxScore = 99999;			// 最大スコア

	// Start is called before the first frame update
	void Start()
	{
		// スコア用テキストオブジェクトを取得
		m_ScoreTextObj = GameObject.Find("ScoreText");

		// スコア用テキストオブジェクトが取得出来ているか確認
		//Debug.Log(GameObject.Find("Text").GetComponent<TextMeshProUGUI>());

		// コンボ用テキストオブジェクトを取得
		m_ScoreTextObj = GameObject.Find("Text");

		// スコアテキストの内初期容を表示
		//Debug.Log(m_Str);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{ // スペースキーを押すとランダムに数値が反映

			m_nTestCnt += Random.Range(0, 100);
		}

		if (m_nTestCnt > m_nMaxScore)
		{ // 数値の上限を設定

			m_nTestCnt = m_nMaxScore;
		}

		// スコアテキスト反映
		m_ScoreTextObj.GetComponent<TextMeshProUGUI>().text = "Score : " + m_nTestCnt;
	}
}