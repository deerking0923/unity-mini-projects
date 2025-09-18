using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Debug.Log("게임종료");
        }
    }*/
   // public GameObject EndingSet;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            // 플레이어 아웃 처리를 수행합니다.
            Debug.Log("플레이어가 장애물과 충돌했습니다!");
            SceneManager.LoadScene("EndingScene");
        }
    }
}
