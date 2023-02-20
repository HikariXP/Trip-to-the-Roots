using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ɽ�������
/// </summary>
public abstract class InteractiveObject : MonoBehaviour
{
    /// <summary>
    /// �ɽ�����
    /// </summary>
    protected bool canInteractive = true;

    /// <summary>
    /// չʾ�ɽ��������壬����һ���ᶯ����ʾ
    /// </summary>
    public GameObject CanInteractiveTips;

    /// <summary>
    /// ����ķ�����
    /// </summary>
    /// <returns></returns>
    public virtual bool Interactive()
    { 
        canInteractive = false;
        return true;
    }

    public bool GetCanInteractive()
    {
        return canInteractive;
    }
}


