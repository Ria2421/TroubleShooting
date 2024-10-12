using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BaseManager : MonoBehaviour
{
// --シーン定義-----------------------------------------------------------------
    /// <summary> Scene変更マネージャ </summary>
    protected GameSceneManager   m_gameSceneManager;

// --タイマー定義-----------------------------------------------------------------
    /// <summary> タイマー終了後デリゲート </summary>
    public delegate void OnFinishedWaitTime();

    /// <summary> 待機中のデリゲート </summary>
    private   OnFinishedWaitTime m_waitTimeDelegate;

    /// <summary> 待機終了時間 </summary>
    private float m_waitEndTime = 0;

    /// <summary> 現在の待機時間 </summary>
    private float m_waitTime = 0;

    private void Awake()
    {
        GameObject obj = GameObject.Find("SceneManager");
        if (obj != null)
        {
            m_gameSceneManager = obj.GetComponent<GameSceneManager>();
        }
        OnAwake();
    }

    /// <summary>
    /// 子用Awake
    /// </summary>
    protected virtual void OnAwake()
    { 
    
    }


    private void Start()
    {
        OnStart();
    }

    /// <summary>
    /// 子用Start
    /// </summary>
    protected virtual void OnStart()
    { 
    
    }

    public void Update()
    {
        if (m_waitTimeDelegate != null)
        {
            m_waitTime += Time.deltaTime;
            if (m_waitTime >= m_waitEndTime)
            {
                m_waitTimeDelegate();
                m_waitTimeDelegate = null;
            }
        }

        OnUpdate();
    }

    /// <summary>
    /// 子用Update
    /// </summary>
    protected virtual void OnUpdate()
    {
    
    }


    /// <summary>
    /// デリゲートを指定時間後実行する
    /// 本来はList管理で実行できるほうがよいが時間がないため１つのみ
    /// </summary>
    /// <param name="_time">時間</param>
    /// <param name="_onfinishWait">実行するメソッド</param>
    /// <returns>可否</returns>
    public bool AddWaitTime( float _time, OnFinishedWaitTime _onfinishWait )
    {
        if ( m_waitTimeDelegate == null )
        {
            m_waitTimeDelegate += _onfinishWait;
            m_waitTime = _time;
        }
        else 
        { 
            return false; 
        }
        return true;
    }

}
