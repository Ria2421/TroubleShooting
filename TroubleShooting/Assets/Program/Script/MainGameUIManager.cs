using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameUIManager : MonoBehaviour
{
	GameObject m_TextObj = null;	// �e�L�X�g�I�u�W�F�N�g���i�[
	int m_nTestCnt = 0;				// �e�X�g�p�̃J�E���g
	int m_nMaxScore = 99999;		// �ő�X�R�A

	// Start is called before the first frame update
	void Start()
	{
		// �e�L�X�g�I�u�W�F�N�g���擾
		m_TextObj = GameObject.Find("ScoreText");

		// �e�L�X�g�p�I�u�W�F�N�g���擾�o���Ă��邩�m�F
		//Debug.Log(GameObject.Find("Text").GetComponent<TextMeshProUGUI>());

		// �����e�L�X�g�̓��e��\��
		//Debug.Log(m_Str);

		Debug.Log(m_nMaxScore);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{ // �X�y�[�X�L�[�������ƃ����_���ɐ��l�����f

			m_nTestCnt += Random.Range(0, 100);
		}

		if (m_nTestCnt > m_nMaxScore)
		{ // ���l�̏����ݒ�

			m_nTestCnt = m_nMaxScore;
		}

		// �e�L�X�g���f
		m_TextObj.GetComponent<TextMeshProUGUI>().text = "Score : " + m_nTestCnt;
	}
}