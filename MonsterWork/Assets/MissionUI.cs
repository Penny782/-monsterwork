using DummyNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MissionUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;      // ���ȦW��
    public TextMeshProUGUI descriptionText; // ���ȴy�z
    public Button actionButton;            // ������Ȫ����s
    private Mission currentMission;        // ���p�����ȸ��

    // ��l�ƥ��� UI
    public void Setup(Mission mission)
    {
        currentMission = mission;
        titleText.text = mission.missionName;
        descriptionText.text = mission.missionDescription;

        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(OnActionButtonClicked);

        UpdateUI();
    }

    // ���U���ȫ��s���欰
    private void OnActionButtonClicked()
    {
        if (!currentMission.isCompleted)
        {
            currentMission.onAction?.Invoke();   // Ĳ�o UnityEvent
            currentMission.isCompleted = true;   // �]������
            UpdateUI();
        }
    }

    // �ھڥ��Ȫ��A��s UI
    private void UpdateUI()
    {
        if (currentMission.isCompleted)
        {
            actionButton.interactable = false;
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "�w����";
        }
        else if (!currentMission.isUnlocked)
        {
            actionButton.interactable = false;
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "�|������";
        }
        else
        {
            actionButton.interactable = true;
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "�}�l����";
        }
    }
}