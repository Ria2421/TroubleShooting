using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameUIManager : MonoBehaviour
{
	GameObject m_ScoreTextObj = null;	// スコア用テキストオブジェクトを格納
	GameObject m_ComboTextObj = null;	// コンボ用テキストオブジェクトを格納
	public int m_nTestCnt = 0;			// スコアの値
	int m_nMaxScore = 99999;			// 最大スコア

	// Start is called before the first frame update
	void Start()
	{
		// スコア用テキストオブジェクトを取得
		m_ScoreTextObj = GameObject.Find("ScoreText");

		// スコア用テキストオブジェクトが取得出来ているか確認
		//Debug.Log(GameObject.Find("Text").GetComponent<TextMeshProUGUI>());

		// コンボ用テキストオブジェクトを取得
		m_ComboTextObj = GameObject.Find("ComboText");

		// コンボ用テキストオブジェクトが取得出来ているか確認
		Debug.Log(m_ComboTextObj.GetComponent<TextMeshProUGUI>());
	}

	// Update is called once per frame
	void Update()
	{
		/* デバッグ用処理 */
		if (Input.GetKeyDown(KeyCode.Space))
		{ // スペースキーを押すとUI用の数値が変化

			// スコア値がランダムに増加
			m_nTestCnt += Random.Range(0, 100);

			// コンボテキストがランダムに変化
			ChangeComboText(Random.Range(0, 10));
		}

		if (m_nTestCnt > m_nMaxScore)
		{ // 数値の上限を設定

			m_nTestCnt = m_nMaxScore;
		}

		// スコア値をテキストに反映
		m_ScoreTextObj.GetComponent<TextMeshProUGUI>().text = "Score : " + m_nTestCnt;
	}

	// コンボ数の変化をテキストに反映
	public void ChangeComboText (int nComboNum)
	{
		m_ComboTextObj.GetComponent<TextMeshProUGUI>().text = "Combo : " + nComboNum;
	}
}