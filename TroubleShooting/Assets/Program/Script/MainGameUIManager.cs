using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameUIManager : MonoBehaviour
{
	GameObject m_ScoreTextObj = null;	// �X�R�A�p�e�L�X�g�I�u�W�F�N�g���i�[
	GameObject m_ComboTextObj = null;	// �R���{�p�e�L�X�g�I�u�W�F�N�g���i�[
	public int m_nTestCnt = 0;			// �X�R�A�̒l
	int m_nMaxScore = 99999;			// �ő�X�R�A

	// Start is called before the first frame update
	void Start()
	{
		// �X�R�A�p�e�L�X�g�I�u�W�F�N�g���擾
		m_ScoreTextObj = GameObject.Find("ScoreText");

		// �X�R�A�p�e�L�X�g�I�u�W�F�N�g���擾�o���Ă��邩�m�F
		//Debug.Log(GameObject.Find("Text").GetComponent<TextMeshProUGUI>());

		// �R���{�p�e�L�X�g�I�u�W�F�N�g���擾
		m_ComboTextObj = GameObject.Find("ComboText");

		// �R���{�p�e�L�X�g�I�u�W�F�N�g���擾�o���Ă��邩�m�F
		Debug.Log(m_ComboTextObj.GetComponent<TextMeshProUGUI>());
	}

	// Update is called once per frame
	void Update()
	{
		/* �f�o�b�O�p���� */
		if (Input.GetKeyDown(KeyCode.Space))
		{ // �X�y�[�X�L�[��������UI�p�̐��l���ω�

			// �X�R�A�l�������_���ɑ���
			m_nTestCnt += Random.Range(0, 100);

			// �R���{�e�L�X�g�������_���ɕω�
			ChangeComboText(Random.Range(0, 10));
		}

		if (m_nTestCnt > m_nMaxScore)
		{ // ���l�̏����ݒ�

			m_nTestCnt = m_nMaxScore;
		}

		// �X�R�A�l���e�L�X�g�ɔ��f
		m_ScoreTextObj.GetComponent<TextMeshProUGUI>().text = "Score : " + m_nTestCnt;
	}

	// �R���{���̕ω����e�L�X�g�ɔ��f
	public void ChangeComboText (int nComboNum)
	{
		m_ComboTextObj.GetComponent<TextMeshProUGUI>().text = "Combo : " + nComboNum;
	}
}