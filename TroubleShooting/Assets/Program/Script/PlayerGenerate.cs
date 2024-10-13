//---------------------------------------------------------------
//
// プレイヤー生成処理 [ PlayerGenerate.cs ]
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
    // フィールド

    /// <summary>
    /// プレイヤープレハブ
    /// </summary>
    [SerializeField] private List<GameObject> playerObjs;

    /// <summary>
    /// ゲームマネージャ
    /// </summary>
    private GameManager gameManager;

    //--------------------------
    // メソッド

    /// <summary>
    /// 初期処理
    /// </summary>
    void Awake()
    {
        // プレイヤーの生成
        GameObject childObj =  Instantiate(playerObjs[Random.Range(0, playerObjs.Count)]);
        childObj.transform.parent = this.transform;
        childObj.name = "Player";

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// プレイヤー生成処理
    /// </summary>
    public void GeneratePlayer()
    {
        // プレイヤーの生成
        GameObject childObj = Instantiate(playerObjs[Random.Range(0, playerObjs.Count)]);
        childObj.transform.parent = this.transform;
    }

    /// <summary>
    /// 接触成功
    /// </summary>
    public void SuccessConnect()
    {
        gameManager.AddScore();
    }

    /// <summary>
    /// 接触失敗
    /// </summary>
    public void FailureConnect()
    {
        // 一応スコア減算処理
        gameManager.SubtractScore();
    }

}
