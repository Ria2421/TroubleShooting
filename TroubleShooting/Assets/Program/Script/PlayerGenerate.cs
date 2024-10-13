//---------------------------------------------------------------
//
// �v���C���[�������� [ PlayerGenerate.cs ]
// Author:Kenta Nakamoto
// Data:2024/10/12
// Update:2024/10/12
//
//---------------------------------------------------------------
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerGenerate : MonoBehaviour
{
    //--------------------------
    // �t�B�[���h

    /// <summary>
    /// �v���C���[�v���n�u
    /// </summary>
    [SerializeField] private List<GameObject> playerObjs;

    /// <summary>
    /// �Q�[���}�l�[�W��
    /// </summary>
    private GameManager gameManager;

    //--------------------------
    // ���\�b�h

    /// <summary>
    /// ��������
    /// </summary>
    void Awake()
    {
        // �v���C���[�̐���
        GameObject childObj =  Instantiate(playerObjs[Random.Range(0, playerObjs.Count)]);
        childObj.transform.parent = this.transform;
        childObj.name = "Player";

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// �v���C���[��������
    /// </summary>
    public void GeneratePlayer()
    {
        // �v���C���[�̐���
        GameObject childObj = Instantiate(playerObjs[Random.Range(0, playerObjs.Count)]);
        childObj.transform.parent = this.transform;
    }

    /// <summary>
    /// �ڐG����
    /// </summary>
    public void SuccessConnect()
    {
        gameManager.AddScore();
    }

    /// <summary>
    /// �ڐG���s
    /// </summary>
    public void FailureConnect()
    {
        // �ꉞ�X�R�A���Z����
        gameManager.SubtractScore();
    }

}
