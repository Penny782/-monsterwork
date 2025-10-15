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
    [Header("���ȵ����P���s")]
    public GameObject missionPanel;//���ȵ���
    public Button closeButton;//�������������s
    
    [Header("��L����s��")]
    public CoinManager coinManager;
    public Button missionButton; // �b Inspector ����
    //public GameObject shopButton;//�ӫ����s(�Ĥ@�ӥ��ȧ�����X�{)


    // �Ĥ@�ӥ��Ȫ��A
    private bool firstMissionCompleted = false;

    void Awake()
    {
        missionPanel.SetActive(false); // �@�}�l�N����
    }

    void Start()
    {
   
    // �j�w�������s�ƥ�
    closeButton.onClick.AddListener(CloseMissionPanel);
    missionButton.onClick.AddListener(OpenMissionPanel);
   
    }

   
    
    /// <summary>
/// �ˬd���ȶi�׻P���ꪬ�A
/// </summary>
    void CheckMissionsProgress()
    {

        if (coinManager == null)
        {
            Debug.LogError("CoinManager �S���Q�����I");
            return;
        }

        Debug.Log("�ثe�_��: " + coinManager.TotalCoins);

        if (!firstMissionCompleted && coinManager != null && coinManager.TotalCoins >= 100)
        {
            firstMissionCompleted = true;
            Debug.Log("�Ĥ@�ӥ��ȧ����A��ܥ��ȵ����I");

            // ��ܥ��ȵ���
            OpenMissionPanel();

          
        }
    }

    /// <summary>
    /// ��ܥ��ȵ����]�b���U���ȫ��s�ɩI�s�^
    /// </summary>
    public void OpenMissionPanel()
    {
        missionPanel.SetActive(true);
    }

    /// <summary>
    /// �������ȵ���
    /// </summary>
    public void CloseMissionPanel()
    {
        missionPanel.SetActive(false);
    }
    void Update()
    {
        // �C�V�L�X�ثe�_���ƶq
        //Debug.Log("�ثe�_��: " + coinManager.TotalCoins);
        CheckMissionsProgress();
    }

}

    
 
    


