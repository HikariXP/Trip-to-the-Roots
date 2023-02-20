using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : InteractiveObject
{
    public override bool Interactive()
    {
        if(!canInteractive)return false;

        PlayResourceManager.instance.PlayerUploadMaterials();

        Debug.Log("Interactive Console");

        return true;
    }
}