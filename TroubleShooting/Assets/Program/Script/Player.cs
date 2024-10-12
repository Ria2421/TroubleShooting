//---------------------------------------------------------------
//
// プレイヤー処理 [ Player.cs ]
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
    // フィールド

    /// <summary>
    /// 操作フラグ
    /// </summary>
    private bool moveFlag = false;

    /// <summary>
    /// プレイヤー生成スクリプト
    /// </summary>
    private PlayerGenerate playerGenerate;

    /// <summary>
    /// エフェクト角度
    /// </summary>
    private Vector3 effectQuaternion;

    /// <summary>
    /// エフェクト位置補正pos
    /// </summary>
    private Vector3 revisionPos;

    /// <summary>
    /// ヒットエフェクト
    /// </summary>
    [SerializeField] private GameObject hitEffect;

    /// <summary>
    /// 移動秒数
    /// </summary>
    [SerializeField] private float moveSecond = 0f;

    /// <summary>
    /// 行動不能秒数
    /// </summary>
    [SerializeField] private float stunSecond = 0f;

    //--------------------------
    // メソッド

    /// <summary>
    /// 初期処理
    /// </summary>
    private void Start()
    {
        playerGenerate = GetComponentInParent<PlayerGenerate>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        if (moveFlag) return;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {   // W・↑キー操作
            moveFlag = true;

            // 移動処理
            this.transform.DOMove(new Vector3(0f, 4f, 0f), moveSecond);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {   // S・↓キー操作
            moveFlag = true;

            // 移動処理
            this.transform.DOMove(new Vector3(0f, -4f, 0f), moveSecond);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {   // A・←キー操作
            moveFlag = true;

            // 移動処理
            this.transform.DOMove(new Vector3(-4f, 0f, 0f), moveSecond);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {   // D・→キー操作
            moveFlag = true;

            // 移動処理
            this.transform.DOMove(new Vector3(4f, 0f, 0f), moveSecond);
        }
    }

    /// <summary>
    /// 衝突したときの処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == this.gameObject.tag)
        {   // 成功時
            

            //++ スコアの加算処理

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

            // hitエフェクト生成
            GameObject effect = Instantiate(hitEffect,this.transform.position + revisionPos,Quaternion.identity);    
            effect.transform.eulerAngles = effectQuaternion;
            playerGenerate.GeneratePlayer();    // 凸生成
            Destroy(this.gameObject);
        }
        else
        {   // 失敗時
            Invoke("Failure", stunSecond);
        }
    }

    /// <summary>
    /// 成功時の処理
    /// </summary>
    private void Success()
    {

    }

    /// <summary>
    /// 失敗時の処理
    /// </summary>
    private void Failure()
    {
        playerGenerate.GeneratePlayer();
        Destroy(this.gameObject);
    }
}
