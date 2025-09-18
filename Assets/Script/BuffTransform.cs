using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTransform : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� Transform ������Ʈ�� �����ϱ� ���� ����

    void Update()
    {
        if (playerTransform != null)
        {
            // ������Ʈ�� ��ġ�� �÷��̾��� ��ġ�� ����
            transform.position = playerTransform.position;
        }
        else
        {
            Debug.LogError("�÷��̾� Transform�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
}



