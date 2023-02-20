using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemRemainUI : MonoBehaviour
{
    private PlayResourceManager resourceManager;

    public TextMeshProUGUI textMeshProA;
    public TextMeshProUGUI textMeshProB;
    public TextMeshProUGUI textMeshProC;

    private void Start()
    {
        resourceManager = PlayResourceManager.instance;
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        textMeshProA.text = resourceManager.GetUploadedMaterialAmount(MaterialDefine.Red).ToString();
        textMeshProB.text = resourceManager.GetUploadedMaterialAmount(MaterialDefine.Green).ToString();
        textMeshProC.text = resourceManager.GetUploadedMaterialAmount(MaterialDefine.Blue).ToString();
    }
}
