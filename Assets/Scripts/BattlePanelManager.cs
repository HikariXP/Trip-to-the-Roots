using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePanelManager : MonoBehaviour
{
    public static BattlePanelManager instance => m_Instance;

    private static BattlePanelManager m_Instance;

    public GameObject BattlePanelBeControl;

    public Transform MaterialFatherPoint;

    public OnPlayerEnter onPlayerEnter;

    public List<GameObject> materialPerfabs = new List<GameObject>();

    public List<MaterialDrop> materialDropRemain = new List<MaterialDrop>();

    /// <summary>
    /// 刷新范围长度(包含正负,比如13就是-13~13)
    /// </summary>
    public float Length = 13f;

    /// <summary>
    /// 刷新范围宽度
    /// </summary>
    public float Width = 10f;

    public float HighDefine = 0.3f;

    public int maxMaterial = 8;

    public int minMaterial = 3;

    private void Awake()
    {
        m_Instance = this;
    }

    private void Start()
    {
        onPlayerEnter.OnPlayerEnterEvent += OnPlayerEnterBattlePanel;

        GameManager.instance.OnPlayerEnterPlayerBasePanelEvent += UpdateBattleAreaUnit;
    }

    /// <summary>
    /// 为
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomPositionInRange()
    {
        var posX = Random.Range(-Width,Width);
        var posZ = Random.Range(-Length,Length);

        return new Vector3(posX,HighDefine, posZ);
    }

    //private Quaternion GetRandomQuaternion() 
    //{ 
    //    return new Quaternion.
    //}

    private GameObject GetRandomMaterialPerfab()
    {
        var randomTemp = Random.Range(0, materialPerfabs.Count);
        return materialPerfabs[randomTemp];
    }

    /// <summary>
    /// 刷新
    /// </summary>
    private void UpdateMaterialDrop()
    {

        //int childCount = MaterialFatherPoint.childCount;
        //for (int i = 0; i < childCount; i++)
        //{
        //    Destroy(MaterialFatherPoint.GetChild(0).gameObject);   
        //}

        for (int i = 0,j = materialDropRemain.Count; i < j; i++)
        {
            Destroy(materialDropRemain[i].gameObject);
        }

        materialDropRemain.Clear();

        var amountThisTime = Random.Range(minMaterial, maxMaterial);
        while(materialDropRemain.Count < amountThisTime)
        {
            var pos = GetRandomPositionInRange();
            GameObject gameOb = Instantiate(GetRandomMaterialPerfab(),Vector3.zero , Quaternion.Euler(0, Random.Range(0f, 360f), 0), MaterialFatherPoint);
            gameOb.transform.localPosition = pos;
            materialDropRemain.Add(gameOb.GetComponent<MaterialDrop>());
        }
    }

    /// <summary>
    /// 当玩家进入战区，让基地迁移位置并且激活基地的Enter
    /// </summary>
    private void OnPlayerEnterBattlePanel()
    {
        onPlayerEnter.isUsed = true;

        GameManager.instance.SetCurrentBattlePanelPosition(BattlePanelBeControl.transform.position);
    }

    /// <summary>
    /// 刷新战区
    /// </summary>
    public void UpdateBattleAreaUnit()
    { 
        var nextPos = GameManager.instance.GetNextBattlePanelPosition();
        nextPos.x = Random.Range(-GameManager.instance.AreaRefreshOffset, GameManager.instance.AreaRefreshOffset);
        BattlePanelBeControl.GetComponent<Transform>().position = nextPos;

        UpdateMaterialDrop();

        onPlayerEnter.isUsed = false;
    }

    public void TestFastRefreshBattlePanel()
    {
        UpdateMaterialDrop();
    }

}