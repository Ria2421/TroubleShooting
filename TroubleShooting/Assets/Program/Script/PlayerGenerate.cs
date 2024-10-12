//---------------------------------------------------------------
//
// �v���C���[�������� [ PlayerGenerate.cs ]
// Author:Kenta Nakamoto
// Data:2024/10/12
// Update:2024/10/12
//
//---------------------------------------------------------------
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

    //--------------------------
    // ���\�b�h

    /// <summary>
    /// ��������
    /// </summary>
    void Start()
    {
        // �v���C���[�̐���
        GameObject childObj =  Instantiate(playerObjs[Random.Range(0, playerObjs.Count)]);
        childObj.transform.parent = this.transform;

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
}
