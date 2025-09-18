using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTransform : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform 컴포넌트를 저장하기 위한 변수

    void Update()
    {
        if (playerTransform != null)
        {
            // 오브젝트의 위치를 플레이어의 위치로 설정
            transform.position = playerTransform.position;
        }
        else
        {
            Debug.LogError("플레이어 Transform이 할당되지 않았습니다.");
        }
    }
}



