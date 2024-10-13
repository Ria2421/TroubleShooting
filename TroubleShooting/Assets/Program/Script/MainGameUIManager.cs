using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameUIManager : MonoBehaviour
{
	GameObject m_ScoreTextObj = null;	// �X�R�A�p�e�L�X�g�I�u�W�F�N�g���i�[
	GameObject m_ComboTextObj = null;	// �R���{�p�e�L�X�g�I�u�W�F�N�g���i�[
	public int m_nTestCnt = 0;			// �e�X�g�p�̃J�E���g
	int m_nMaxScore = 99999;			// �ő�X�R�A

	// Start is called before the first frame update
	void Start()
	{
		// �X�R�A�p�e�L�X�g�I�u�W�F�N�g���擾
		m_ScoreTextObj = GameObject.Find("ScoreText");

		// �X�R�A�p�e�L�X�g�I�u�W�F�N�g���擾�o���Ă��邩�m�F
		//Debug.Log(GameObject.Find("Text").GetComponent<TextMeshProUGUI>());

		// �R���{�p�e�L�X�g�I�u�W�F�N�g���擾
		m_ScoreTextObj = GameObject.Find("Text");

		// �X�R�A�e�L�X�g�̓������e��\��
		//Debug.Log(m_Str);
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

		// �X�R�A�e�L�X�g���f
		m_ScoreTextObj.GetComponent<TextMeshProUGUI>().text = "Score : " + m_nTestCnt;
	}
}