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
            // 플레이어 아웃 처리를 수행합니다.
            Debug.Log("플레이어가 조개와 충돌했습니다!");
            SceneManager.LoadScene("EndingScene");
        }
        /*if (collision.gameObject.CompareTag("bullet"))
        {
            // 상대를 파괴한다
            Destroy(collision.gameObject);

            HP -= 10;
            // 자신을 파괴한다
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
