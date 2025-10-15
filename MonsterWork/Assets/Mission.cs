using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ���ȸ�Ƶ��c�]�i�b Inspector ���]�w�^
/// </summary>
[System.Serializable]

public class Mission
{
    public string missionName;         // ���ȦW��
    public string missionDescription;  // ���ȴy�z
    public bool isCompleted;           // �O�_����
    public bool isUnlocked;            // �O�_����
    public UnityEvent onAction;        // �I�����ȫ��s�ɭnĲ�o���ƥ�]�i�b Inspector �]�w�^
}