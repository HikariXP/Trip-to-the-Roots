using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// 玩家的总仓库管理。
/// </summary>
public class PlayResourceManager : MonoBehaviour
{
    public static PlayResourceManager instance=>m_Instance;

    private static PlayResourceManager m_Instance;
    /// <summary>
    /// 玩家材料仓库
    /// </summary>
    public int MaterialsRed { get; private set; }
    public int MaterialsGreen { get; private set; }
    public int MaterialsBlue { get; private set; }

    /// <summary>
    /// 当玩家收集到足够的材料的时候出发
    /// </summary>
    public event Action OnPlayerFinsihMaterialEvent;

    public List<MaterialDefine> materials = new List<MaterialDefine>();


    private void Awake()
    {
        m_Instance = this;
    }
    /// <summary>
    /// 清空玩家的库存并上传
    /// </summary>
    public void PlayerUploadMaterials()
    {
        foreach (MaterialDefine md in materials)
        { 
            switch(md)
            {
                case MaterialDefine.Red:MaterialsRed += 1;break;
                case MaterialDefine.Green: MaterialsGreen += 1;break;
                case MaterialDefine.Blue: MaterialsBlue += 1;break;
            }
        }
        materials.Clear();

        OnCheckGameOver();
    }

    /// <summary>
    /// 获取现在一共收集了多少资源
    /// </summary>
    /// <param name="materialDefine"></param>
    /// <returns></returns>
    public int GetUploadedMaterialAmount(MaterialDefine materialDefine)
    {
        switch (materialDefine)
        {
            case MaterialDefine.Red: return MaterialsRed;
            case MaterialDefine.Green: return MaterialsGreen;
            case MaterialDefine.Blue: return MaterialsBlue;
            default: return 0;
        }
    }

    public int GetAllMaterialUploadAmmount()
    {
        var answer = GetUploadedMaterialAmount(MaterialDefine.Red) + GetUploadedMaterialAmount(MaterialDefine.Blue) + GetUploadedMaterialAmount(MaterialDefine.Green);
        return answer;
    }

    public void OnCheckGameOver()
    {
        if (MaterialsRed < GameManager.instance.materialARequired) return;
        if (MaterialsGreen < GameManager.instance.materialBRequired) return;
        if (MaterialsBlue < GameManager.instance.materialCRequired) return;

        OnPlayerFinsihMaterialEvent?.Invoke();
    }

    public void ResetAll()
    {
        MaterialsRed = 0; MaterialsGreen=0; MaterialsBlue=0;
        materials.Clear() ;
    }
}

/// <summary>
/// 材料类型定义
/// </summary>
public enum MaterialDefine
{
    Red,
    Green,
    Blue
}
