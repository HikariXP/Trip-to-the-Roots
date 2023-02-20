using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiEventSystem : MonoBehaviour
{
    public static SuiEventSystem instance=>_instance;

    private static SuiEventSystem _instance;

    private void Awake()
    {
        _instance = this;
    }
}

public struct EventDefine
{
    public const int on_interactive_finish = 50;
}
