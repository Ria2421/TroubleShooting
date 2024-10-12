using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameTimerManager : MonoBehaviour
{
	private GameObject m_TextObj = null;	// テキストオブジェクトを格納

	[SerializeField]
	private float m_fLimit = 0.0f;		// 制限時間を格納

	// Start is called before the first frame update
	void Start()
	{
		// テキストオブジェクトを取得
		m_TextObj = GameObject.Find("TimerText");
	}

	// Update is called once per frame
	void Update()
	{
		if (m_fLimit > 0.0f)
		{
			// 時間経過により減少
			m_fLimit -= Time.deltaTime;

			// 小数第3位以下を切り捨て
			string Str = m_fLimit.ToString("F2");

			// テキスト反映
			m_TextObj.GetComponent<TextMeshProUGUI>().text = "Limit : " + Str;
		}
		else
		{ // 時間が無くなったら

			// 仮として終了状態を表示
			Debug.Log("終了しました！");

			/* 終了処理 */
		}
	}
}