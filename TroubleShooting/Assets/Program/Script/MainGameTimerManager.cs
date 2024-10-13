using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening.Core.Easing;

public class MainGameTimerManager : MonoBehaviour
{
	private GameManager m_GameManager = null;
	private GameObject m_TextObj = null;    // �e�L�X�g�I�u�W�F�N�g���i�[
	public bool cantCountFlag = true;

	[SerializeField]
	private float m_fLimit = 0.0f;		// �������Ԃ��i�[

	// Start is called before the first frame update
	void Start()
	{
		// �e�L�X�g�I�u�W�F�N�g���擾
		m_TextObj = GameObject.Find("TimerText");
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
	{
		if (cantCountFlag) return;

		if (m_fLimit > 0.0f)
		{
			// ���Ԍo�߂ɂ�茸��
			m_fLimit -= Time.deltaTime;

			// ������3�ʈȉ���؂�̂�
			string Str = m_fLimit.ToString("F2");

			// �e�L�X�g���f
			m_TextObj.GetComponent<TextMeshProUGUI>().text = "Limit : " + Str;
		}
		else
		{ // ���Ԃ������Ȃ�����

			// ���Ƃ��ďI����Ԃ�\��
			Debug.Log("�I�����܂����I");

			m_GameManager.FinishMainGame();

            /* �I������ */
        }
	}
}