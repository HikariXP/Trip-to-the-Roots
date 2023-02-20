using System.Collections;
using UnityEngine;

/// <summary>
/// ≤ƒ¡œµÙ¬‰ŒÔ
/// </summary>
public class MaterialDrop : InteractiveObject
{
    private Animator animator;

    public MaterialDefine materialDefine;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override bool Interactive()
    {
        animator.SetTrigger("Interactive");

        canInteractive = false;

        OnAddMaterialToPlayer();

        return true;
    }

    private void OnAddMaterialToPlayer()
    {
        switch (materialDefine)
        {
            case MaterialDefine.Red: PlayResourceManager.instance.materials.Add(MaterialDefine.Red);break;
            case MaterialDefine.Green: PlayResourceManager.instance.materials.Add(MaterialDefine.Green); break;
            case MaterialDefine.Blue: PlayResourceManager.instance.materials.Add(MaterialDefine.Blue); break;
            default: break;
        }
    }
}


