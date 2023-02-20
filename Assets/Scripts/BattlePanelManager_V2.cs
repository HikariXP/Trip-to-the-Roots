using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattlePanelManager_V2 : MonoBehaviour
{
    public static BattlePanelManager_V2 instance => m_Instance;

    private static BattlePanelManager_V2 m_Instance;

    public GameObject BattlePanelBeControl;

    public OnPlayerEnter onPlayerEnter;

    [Tooltip("可被刷新刷到的[材料]预制体")]
    public List<GameObject> MaterialPerfabList= new List<GameObject>();

    [Tooltip("可被刷新刷到的[阻碍]预制体")]
    public List<GameObject> BlockPerfabList = new List<GameObject>();

    public GameObject RefreshPointFatherPoint;

    public List<Transform> RefreshPointTrans;

    public List<GameObject> InstantiateGameObject = new List<GameObject>();

    public int maxMaterial = 6;

    public int minMaterial = 3;

    public int MaterialPercent = 20;

    public int BlockPercent = 60;

    private void Awake()
    {
        m_Instance = this;
    }

    private void Start()
    {
        onPlayerEnter.OnPlayerEnterEvent += OnPlayerEnterBattlePanel;

        GameManager.instance.OnPlayerEnterPlayerBasePanelEvent += UpdateBattleAreaUnit;

        RefreshPointTrans = RefreshPointFatherPoint.GetComponentsInChildren<Transform>().ToList();

        RefreshPointTrans.Remove(RefreshPointFatherPoint.transform);
    }

    /// <summary>
    /// 为
    /// </summary>
    /// <returns></returns>
    //private Vector3 GetRandomPositionInRange()
    //{
    //    var posX = Random.Range(-Width, Width);
    //    var posZ = Random.Range(-Length, Length);

    //    return new Vector3(posX, HighDefine, posZ);
    //}

    //private Quaternion GetRandomQuaternion() 
    //{ 
    //    return new Quaternion.
    //}

    //private GameObject GetRandomMaterialPerfab()
    //{
    //    var randomTemp = Random.Range(0, materialPerfabs.Count);
    //    return materialPerfabs[randomTemp];
    //}

    /// <summary>
    /// 刷新
    /// </summary>
    //private void UpdateMaterialDrop()
    //{

    //    //int childCount = MaterialFatherPoint.childCount;
    //    //for (int i = 0; i < childCount; i++)
    //    //{
    //    //    Destroy(MaterialFatherPoint.GetChild(0).gameObject);   
    //    //}

    //    for (int i = 0, j = materialDropRemain.Count; i < j; i++)
    //    {
    //        Destroy(materialDropRemain[i].gameObject);
    //    }

    //    materialDropRemain.Clear();

    //    var amountThisTime = Random.Range(minMaterial, maxMaterial);
    //    while (materialDropRemain.Count < amountThisTime)
    //    {
    //        var pos = GetRandomPositionInRange();
    //        GameObject gameOb = Instantiate(GetRandomMaterialPerfab(), Vector3.zero, Quaternion.Euler(0, Random.Range(0f, 360f), 0), MaterialFatherPoint);
    //        gameOb.transform.localPosition = pos;
    //        materialDropRemain.Add(gameOb.GetComponent<MaterialDrop>());
    //    }
    //}

    private void UpdateAllItem()
    {
        //foreach (Transform tr in RefreshPointTrans)
        //{
        //    int randomInt = Random.Range(0, 100);
        //    if (randomInt < MaterialPercent)
        //    {
        //        var material = Instantiate(MaterialPerfabList[Random.Range(0, MaterialPerfabList.Count)]);

        //    }
        //    else if (randomInt < BlockPercent)
        //    {
        //        var block = Instantiate
        //        InstantiateGameObject +=
        //    }
        //}
    }

    /// <summary>
    /// 当玩家进入战区，让基地迁移位置并且激活基地的Enter
    /// </summary>
    private void OnPlayerEnterBattlePanel()
    {
        onPlayerEnter.isUsed = true;

        GameManager.instance.SetCurrentBattlePanelPosition(BattlePanelBeControl.transform.position);

        //UpdateBattleAreaUnit();
    }

    /// <summary>
    /// 刷新战区
    /// </summary>
    public void UpdateBattleAreaUnit()
    {
        var nextPos = GameManager.instance.GetNextBattlePanelPosition();

        BattlePanelBeControl.GetComponent<Transform>().position = nextPos;

        //UpdateMaterialDrop();

        onPlayerEnter.isUsed = false;
    }
}
