using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BaseManager : MonoBehaviour
{
// --�V�[����`-----------------------------------------------------------------
    /// <summary> Scene�ύX�}�l�[�W�� </summary>
    protected GameSceneManager   m_gameSceneManager;

// --�^�C�}�[��`-----------------------------------------------------------------
    /// <summary> �^�C�}�[�I����f���Q�[�g </summary>
    public delegate void OnFinishedWaitTime();

    /// <summary> �ҋ@���̃f���Q�[�g </summary>
    private   OnFinishedWaitTime m_waitTimeDelegate;

    /// <summary> �ҋ@�I������ </summary>
    private float m_waitEndTime = 0;

    /// <summary> ���݂̑ҋ@���� </summary>
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
    /// �q�pAwake
    /// </summary>
    protected virtual void OnAwake()
    { 
    
    }


    private void Start()
    {
        OnStart();
    }

    /// <summary>
    /// �q�pStart
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
    /// �q�pUpdate
    /// </summary>
    protected virtual void OnUpdate()
    {
    
    }


    /// <summary>
    /// �f���Q�[�g���w�莞�Ԍ���s����
    /// �{����List�Ǘ��Ŏ��s�ł���ق����悢�����Ԃ��Ȃ����߂P�̂�
    /// </summary>
    /// <param name="_time">����</param>
    /// <param name="_onfinishWait">���s���郁�\�b�h</param>
    /// <returns>��</returns>
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
