using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayColliderManager : MonoBehaviour
{
    private const string interactiveTagDefine = "Interactivable";

    public ThirdPersonController controller;

    [SerializeField]
    private List<InteractiveObject> m_InteractiveObjects = new List<InteractiveObject>();

    private void Start()
    {
        controller.colliderManager = this;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(interactiveTagDefine))
        {
            var component = other.GetComponent<InteractiveObject>();
            if (!component) return;
            m_InteractiveObjects.Add(component);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(interactiveTagDefine))
        {
            var component = other.GetComponent<InteractiveObject>();
            if (!component) return;
            m_InteractiveObjects.Remove(component);
        }
    }

    /// <summary>
    /// 当玩家控制器调用互动
    /// </summary>
    public bool OnInteractive()
    {
        var count = m_InteractiveObjects.Count;

        if (count <= 0) return false;

        var result = m_InteractiveObjects[count-1].Interactive();

        m_InteractiveObjects.Remove(m_InteractiveObjects[count - 1]);



        return result;
    }

    //public InteractiveObject GetMoseCloseObject()
    //{ 
    //    foreach(InteractiveObject io in )
    //}
}
