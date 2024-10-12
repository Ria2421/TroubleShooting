using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameUIManager : MonoBehaviour
{
	GameObject m_TextObj = null;	// テキストオブジェクトを格納
	int m_nTestCnt = 0;				// テスト用のカウント
	int m_nMaxScore = 99999;		// 最大スコア

	// Start is called before the first frame update
	void Start()
	{
		// テキストオブジェクトを取得
		m_TextObj = GameObject.Find("ScoreText");

		// テキスト用オブジェクトが取得出来ているか確認
		//Debug.Log(GameObject.Find("Text").GetComponent<TextMeshProUGUI>());

		// 初期テキストの内容を表示
		//Debug.Log(m_Str);

		Debug.Log(m_nMaxScore);
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

		// テキスト反映
		m_TextObj.GetComponent<TextMeshProUGUI>().text = "Score : " + m_nTestCnt;
	}
}