using DummyNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MissionUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;      // 任務名稱
    public TextMeshProUGUI descriptionText; // 任務描述
    public Button actionButton;            // 執行任務的按鈕
    private Mission currentMission;        // 關聯的任務資料

    // 初始化任務 UI
    public void Setup(Mission mission)
    {
        currentMission = mission;
        titleText.text = mission.missionName;
        descriptionText.text = mission.missionDescription;

        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(OnActionButtonClicked);

        UpdateUI();
    }

    // 按下任務按鈕的行為
    private void OnActionButtonClicked()
    {
        if (!currentMission.isCompleted)
        {
            currentMission.onAction?.Invoke();   // 觸發 UnityEvent
            currentMission.isCompleted = true;   // 設為完成
            UpdateUI();
        }
    }

    // 根據任務狀態更新 UI
    private void UpdateUI()
    {
        if (currentMission.isCompleted)
        {
            actionButton.interactable = false;
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "已完成";
        }
        else if (!currentMission.isUnlocked)
        {
            actionButton.interactable = false;
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "尚未解鎖";
        }
        else
        {
            actionButton.interactable = true;
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "開始任務";
        }
    }
}