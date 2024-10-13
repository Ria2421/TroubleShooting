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
using DG.Tweening.Core.Easing;
using KanKikuchi.AudioManager;

public class Player : BaseManager
{
    //--------------------------
    // �t�B�[���h

    /// <summary>
    /// ����s�\�t���O
    /// </summary>
    public bool cantMoveFlag = false;

    /// <summary>
    /// �v���C���[�����X�N���v�g
    /// </summary>
    private PlayerGenerate playerGenerate;

    /// <summary>
    /// �G�t�F�N�g�p�x
    /// </summary>
    private Vector3 effectQuaternion;

    /// <summary>
    /// �G�t�F�N�g�ʒu�␳pos
    /// </summary>
    private Vector3 revisionPos;

    /// <summary>
    /// �q�b�g�G�t�F�N�g [0:�q�b�g 1:�o�� 2:����]
    /// </summary>
    [SerializeField] private List<GameObject> effects;

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
        SEManager.Instance.Play(SEPath.APPEAR_01);
        Instantiate(effects[2]);
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    private void Update()
    {
        if (cantMoveFlag) return;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {   // W�E���L�[����
            cantMoveFlag = true;

            // �ړ�����
            this.transform.DOMove(new Vector3(0f, 4f, 0f), moveSecond);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {   // S�E���L�[����
            cantMoveFlag = true;

            // �ړ�����
            this.transform.DOMove(new Vector3(0f, -4f, 0f), moveSecond);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {   // A�E���L�[����
            cantMoveFlag = true;

            // �ړ�����
            this.transform.DOMove(new Vector3(-4f, 0f, 0f), moveSecond);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {   // D�E���L�[����
            cantMoveFlag = true;

            // �ړ�����
            this.transform.DOMove(new Vector3(4f, 0f, 0f), moveSecond);
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

            switch (collision.gameObject.tag)
            {
                case "Up":
                    effectQuaternion = new Vector3(0,180f,180f);
                    revisionPos = new Vector3(0, -0.5f, 0);
                    break;

                case "Down":
                    effectQuaternion = new Vector3(0, 180f, 0f);
                    revisionPos = new Vector3(0, 0.5f, 0);
                    break;

                case "Right":
                    effectQuaternion = new Vector3(0, 180f, 270f);
                    revisionPos = new Vector3(-0.5f,0,0);
                    break;

                case "Left":
                    effectQuaternion = new Vector3(0, 180f, 90f);
                    revisionPos = new Vector3(0.5f, 0, 0);
                    break;

                default:
                    break;
            }

            // hit�G�t�F�N�g����
            GameObject effect = Instantiate(effects[0],this.transform.position + revisionPos,Quaternion.identity);
            Instantiate(effects[1], this.transform.position + revisionPos, Quaternion.identity);
            effect.transform.eulerAngles = effectQuaternion;

            SEManager.Instance.Play(SEPath.DECIDE);
            playerGenerate.GeneratePlayer();    // �ʐ���

            playerGenerate.SuccessConnect();
            Destroy(this.gameObject);
        }
        else
        {   // ���s��
            SEManager.Instance.Play(SEPath.STUN);
            Instantiate(effects[3]);    // �ł����̃o�[����
            //Instantiate(effects[3], this.transform.position, Quaternion.identity);  // �ʂ̈ʒu�Ŕ���

            Invoke("Failure", stunSecond);

            playerGenerate.FailureConnect();
        }
    }

    /// <summary>
    /// �������̏���
    /// </summary>
    private void Success()
    {

    }

    /// <summary>
    /// ���s���̏���
    /// </summary>
    private void Failure()
    {
        playerGenerate.GeneratePlayer();
        Destroy(this.gameObject);
    }

    /// <summary>
    /// ���͗L���ݒ�
    /// </summary>
    /// <param name="_enable"></param>
    public void SetEnableInput(bool _enable)
    {
        cantMoveFlag = _enable;
    }
}
