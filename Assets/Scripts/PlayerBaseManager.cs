using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseManager : MonoBehaviour
{
    public static PlayerBaseManager instance => m_Instance;

    private static PlayerBaseManager m_Instance;

    public GameObject PlayerBaseBeControl;

    public Transform playerRespawnPoint;

    public OnPlayerEnter onPlayerEnter;

    private void Awake()
    {
        m_Instance = this;
    }

    private void Start()
    {
        onPlayerEnter.OnPlayerEnterEvent += OnPlayerEnterBattlePanel;

        GameManager.instance.OnPlayerEnterBattlePanelEvent += UpdatePlayerBaseArea;
    }


    /// <summary>
    /// 当玩家进入基地，让战区迁移位置并且激活战区的Enter
    /// </summary>
    private void OnPlayerEnterBattlePanel()
    {
        onPlayerEnter.isUsed = true;

        GameManager.instance.SetCurrentPlayerBasePanelPosition(PlayerBaseBeControl.transform.position);

        //UpdatePlayerBaseArea();
    }

    public void UpdatePlayerBaseArea()
    {
        var nextPos = GameManager.instance.GetNextPlayerBasePanelLocation();
        nextPos.x = Random.Range(-GameManager.instance.AreaRefreshOffset, GameManager.instance.AreaRefreshOffset);
        PlayerBaseBeControl.GetComponent<Transform>().position = nextPos;

        onPlayerEnter.isUsed = false;
    }

    public Vector3 GetRespawnPos()
    {
        return playerRespawnPoint.position;
    }
}
