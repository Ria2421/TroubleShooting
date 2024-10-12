//---------------------------------------------------------------
//
// �v���C���[���� [ Player.cs ]
// Author:Kenta Nakamoto
// Data:2024/10/12
// Update:2024/10/12
//
//---------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    //--------------------------
    // �t�B�[���h

    /// <summary>
    /// ����t���O
    /// </summary>
    private bool moveFlag = false;

    /// <summary>
    /// �v���C���[�����X�N���v�g
    /// </summary>
    private PlayerGenerate playerGenerate;

    /// <summary>
    /// �ړ��b��
    /// </summary>
    [SerializeField] private float moveSecond = 0f;

    /// <summary>
    /// �s���s�\�b��
    /// </summary>
    [SerializeField] private float stunSecond = 0f;

    //--------------------------
    // ���\�b�h

    /// <summary>
    /// ��������
    /// </summary>
    private void Start()
    {
        playerGenerate = GetComponentInParent<PlayerGenerate>();
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    private void Update()
    {
        if (moveFlag) return;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {   // W�E���L�[����
            moveFlag = true;

            // �ړ�����
            this.transform.DOMove(new Vector3(0f, 5f, 0f), moveSecond);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {   // S�E���L�[����
            moveFlag = true;

            // �ړ�����
            this.transform.DOMove(new Vector3(0f, -5f, 0f), moveSecond);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {   // A�E���L�[����
            moveFlag = true;

            // �ړ�����
            this.transform.DOMove(new Vector3(-5f, 0f, 0f), moveSecond);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {   // D�E���L�[����
            moveFlag = true;

            // �ړ�����
            this.transform.DOMove(new Vector3(5f, 0f, 0f), moveSecond);
        }
    }

    /// <summary>
    /// �Փ˂����Ƃ��̏���
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == this.gameObject.tag)
        {   // ������

            //++ �X�R�A�̉��Z����

            playerGenerate.GeneratePlayer();
            Destroy(this.gameObject);
        }
        else
        {   // ���s��
            Invoke("Failure", stunSecond);
            this.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// ���s���̏���
    /// </summary>
    private void Failure()
    {
        playerGenerate.GeneratePlayer();
        Destroy(this.gameObject);
    }
}
