using DummyNamespace;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MissionManager : MonoBehaviour
{
    [Header("任務視窗與按鈕")]
    public GameObject missionPanel;//任務視窗
    public Button closeButton;//關閉視窗的按鈕
    
    [Header("其他物件連結")]
    public CoinManager coinManager;
    public Button missionButton; // 在 Inspector 指派
    //public GameObject shopButton;//商城按鈕(第一個任務完成後出現)


    // 第一個任務狀態
    private bool firstMissionCompleted = false;

    void Awake()
    {
        missionPanel.SetActive(false); // 一開始就隱藏
    }

    void Start()
    {
   
    // 綁定關閉按鈕事件
    closeButton.onClick.AddListener(CloseMissionPanel);
    missionButton.onClick.AddListener(OpenMissionPanel);
   
    }

   
    
    /// <summary>
/// 檢查任務進度與解鎖狀態
/// </summary>
    void CheckMissionsProgress()
    {

        if (coinManager == null)
        {
            Debug.LogError("CoinManager 沒有被指派！");
            return;
        }

        Debug.Log("目前寶錢: " + coinManager.TotalCoins);

        if (!firstMissionCompleted && coinManager != null && coinManager.TotalCoins >= 100)
        {
            firstMissionCompleted = true;
            Debug.Log("第一個任務完成，顯示任務視窗！");

            // 顯示任務視窗
            OpenMissionPanel();

          
        }
    }

    /// <summary>
    /// 顯示任務視窗（在按下任務按鈕時呼叫）
    /// </summary>
    public void OpenMissionPanel()
    {
        missionPanel.SetActive(true);
    }

    /// <summary>
    /// 關閉任務視窗
    /// </summary>
    public void CloseMissionPanel()
    {
        missionPanel.SetActive(false);
    }
    void Update()
    {
        // 每幀印出目前寶錢數量
        //Debug.Log("目前寶錢: " + coinManager.TotalCoins);
        CheckMissionsProgress();
    }

}

    
 
    


