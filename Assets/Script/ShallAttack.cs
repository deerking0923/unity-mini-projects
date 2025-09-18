using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShallAttack : MonoBehaviour
{

    public float speed;
    float HP = 20f;
    // Start is called before the first frame update
    void Start()
    {
   
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("wall"))
        {
            DestroyBullet();
        }
        if (collision.gameObject.CompareTag("player"))
        {
            if (playerAttack.buffCat == 1) return;
            // �÷��̾� �ƿ� ó���� �����մϴ�.
            Debug.Log("�÷��̾ ������ �浹�߽��ϴ�!");
            SceneManager.LoadScene("EndingScene");
        }
        /*if (collision.gameObject.CompareTag("bullet"))
        {
            // ��븦 �ı��Ѵ�
            Destroy(collision.gameObject);

            HP -= 10;
            // �ڽ��� �ı��Ѵ�
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }*/
    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
