//---------------------------------------------------------------
//
// プレイヤー生成処理 [ PlayerGenerate.cs ]
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
    // フィールド

    /// <summary>
    /// プレイヤープレハブ
    /// </summary>
    [SerializeField] private List<GameObject> playerObjs;

    //--------------------------
    // メソッド

    /// <summary>
    /// 初期処理
    /// </summary>
    void Start()
    {
        // プレイヤーの生成
        GameObject childObj =  Instantiate(playerObjs[Random.Range(0, playerObjs.Count)]);
        childObj.transform.parent = this.transform;

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
}
