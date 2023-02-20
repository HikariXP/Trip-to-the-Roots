using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance => m_Instance;

    private static GameManager m_Instance;

    public GameObject Player;

    public CountDownManager CountDownManager;

    public int materialARequired;

    public int materialBRequired;

    public int materialCRequired;

    public GameObject EndUi;

    public float EndScore;

    public Text ScoreText;

    public bool isGameOver { get; private set; }

    /// <summary>
    /// 全局刷新次数
    /// </summary>
    private int m_PanelRefreshTime;
    private int PanelRefreshTime => m_PanelRefreshTime / 2;

    /// <summary>
    /// 偏移
    /// </summary>
    public Vector3 nextPlayerBasePanelOffset;

    /// <summary>
    /// 偏移
    /// </summary>
    public Vector3 nextBattlePanelOffset;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 nextPlayerBasePanelLocation;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 nextBattlePanelLocation;

    public event Action OnPlayerEnterPlayerBasePanelEvent;

    public event Action OnPlayerEnterBattlePanelEvent;

    public event Action GroundPanelRefreshEvent;

    public int MaterialRequireMin = 2;
    public int MaterialRequireMax = 5;

    public TextMeshProUGUI RequireTextA;
    public TextMeshProUGUI RequireTextB;
    public TextMeshProUGUI RequireTextC;

    //区块刷新偏移
    public float AreaRefreshOffset = 5f;

    public void Awake()
    {
        m_Instance = this;
    }

    private void Start()
    {
        GroundPanelRefreshEvent += OnGroundPanelRefresh;

        ResetGame();

        RegisterEvent();
    }

    private void RegisterEvent()
    {
        //订阅倒计时结束时间
        CountDownManager.CountDownEndEvent += OnGameOver;
        //订阅材料上交
        PlayResourceManager.instance.OnPlayerFinsihMaterialEvent += OnGameOver;
    }

    /// <summary>
    /// 获取下一个基地点位的定位
    /// </summary>
    /// <returns></returns>
    public Vector3 GetNextPlayerBasePanelLocation()
    { 
        return nextPlayerBasePanelLocation;
    }

    /// <summary>
    /// 获取下一个战区点位的定位
    /// </summary>
    /// <returns></returns>
    public Vector3 GetNextBattlePanelPosition()
    {
        return nextBattlePanelLocation;
    }

    /// <summary>
    /// [基地调用]设置当前基地位置,让管理器计算下个战区的位置
    /// </summary>
    /// <param name="nextPosition"></param>
    public void SetCurrentPlayerBasePanelPosition(Vector3 currentPos)
    {
        nextBattlePanelLocation = currentPos + nextBattlePanelOffset;

        OnPlayerEnterPlayerBasePanelEvent?.Invoke();

        GroundPanelRefreshEvent?.Invoke();
    }

    /// <summary>
    /// [战区调用]设置当前战区位置,让管理器计算下个基地的位置
    /// </summary>
    /// <param name="currentPos"></param>
    public void SetCurrentBattlePanelPosition(Vector3 currentPos)
    {
        nextPlayerBasePanelLocation = currentPos + nextPlayerBasePanelOffset;

        OnPlayerEnterBattlePanelEvent?.Invoke();

        GroundPanelRefreshEvent?.Invoke();
    }

    private void OnGroundPanelRefresh()
    {
        m_PanelRefreshTime += 1;
        Debug.Log(m_PanelRefreshTime);
    }

    public void OnGameOver()
    {
        EndUi.SetActive(true);
        float Score = 0;
        DateTime GameOverTime = DateTime.Now;
        int AllMaterialGet = PlayResourceManager.instance.GetAllMaterialUploadAmmount();
        int TimeRemain = (GameOverTime - CountDownManager.EndTime).Seconds;
        if(TimeRemain > 0) 
        {
            Score += (1 * TimeRemain);
        }

        Score = AllMaterialGet * 20;

        Score += PanelRefreshTime * 8;

        EndScore = (int)Score*114;

        

        ScoreText.text = EndScore.ToString();
    }

    public void RespawnPlayer()
    {
        Player.transform.position = PlayerBaseManager.instance.GetRespawnPos();
    }

    public void ResetGame()
    {
        //改变状态
        isGameOver = false;
        //重设玩家
        RespawnPlayer();
        //开始倒计时
        CountDownManager.StartCountDown();
        //刷新资源
        BattlePanelManager.instance.TestFastRefreshBattlePanel();
        //相关数据清零
        m_PanelRefreshTime = 0;
        PlayResourceManager.instance.ResetAll();

        RefreshMaterialRequire();

    }

    private void RefreshMaterialRequire()
    {
        materialARequired = UnityEngine.Random.Range(MaterialRequireMin, MaterialRequireMax+1);
        materialBRequired = UnityEngine.Random.Range(MaterialRequireMin, MaterialRequireMax + 1); materialCRequired = UnityEngine.Random.Range(MaterialRequireMin, MaterialRequireMax + 1);

        RequireTextA.text = materialARequired.ToString();
        RequireTextB.text = materialBRequired.ToString();
        RequireTextC.text = materialCRequired.ToString();
    }
}
