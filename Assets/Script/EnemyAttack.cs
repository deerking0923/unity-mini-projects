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
            Debug.Log("��������");
        }
    }*/
   // public GameObject EndingSet;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            // �÷��̾� �ƿ� ó���� �����մϴ�.
            Debug.Log("�÷��̾ ��ֹ��� �浹�߽��ϴ�!");
            SceneManager.LoadScene("EndingScene");
        }
    }
}
