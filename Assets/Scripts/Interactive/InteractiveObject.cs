using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可交互物体
/// </summary>
public abstract class InteractiveObject : MonoBehaviour
{
    /// <summary>
    /// 可交互的
    /// </summary>
    protected bool canInteractive = true;

    /// <summary>
    /// 展示可交互的物体，比如一个会动的提示
    /// </summary>
    public GameObject CanInteractiveTips;

    /// <summary>
    /// 激活的方法。
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


