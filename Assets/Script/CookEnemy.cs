using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookEnemy : MonoBehaviour
{

    public static float AttackDamage = 10f;
    public float speed = 3f;
    public float HP = 30f;
    private Animator animator;
    float Originspeed = 3f;


    Vector2 dir;
    void Start()
    {
        Originspeed = speed;
        animator = GetComponent<Animator>();
        
    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        Vector3 currentPosition = transform.position;

        // 만약 y 좌표가 7 이상인 경우
        if (currentPosition.y >= 4.5f && speed <= -1.0f)
        {
            speed = 0f;
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ice"))
        {
            Debug.Log("얼음수류탄 작동");
            StartCoroutine(IceBoom());
        }
        if (collision.gameObject.CompareTag("Electric"))
        {
            Debug.Log("전기수류탄 작동");
            StartCoroutine(ElrctricBoom());
        }
        if (collision.gameObject.CompareTag("Wind"))
        {
            Debug.Log("회오리수류탄 작동");
            StartCoroutine(WindBoom());
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            DestroyEnemy();
        }
        if (collision.gameObject.CompareTag("player"))
        {
            if (playerAttack.buffCat == 1) return;
            // 플레이어 아웃 처리를 수행합니다.
            Debug.Log("플레이어가 문어와 충돌했습니다!");
            SceneManager.LoadScene("EndingScene");
        }

        if (collision.gameObject.CompareTag("bullet"))
        {
            // 상대를 파괴한다
            Destroy(collision.gameObject);

            HP -= AttackDamage;
            // 자신을 파괴한다
            if (HP <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                //GetComponent<Image>().enabled = false;
                speed = 0;
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = false;
                StartCoroutine(DestroyCookEnemy());
                //Destroy(gameObject);
                Score.score += 10;
            }
        }
    }

    private IEnumerator DestroyCookEnemy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private IEnumerator IceBoom()
    {
        //animator.SetTrigger("EnemyIce");
        speed = 0f;
        yield return new WaitForSeconds(3f);
        speed = Originspeed;
        //animator.SetTrigger("EnemyMove");
    }
    private IEnumerator ElrctricBoom()
    {
        speed = Originspeed / 2;
        HP /= 2;
        yield return new WaitForSeconds(3f);
        speed = Originspeed;
    }
    private IEnumerator WindBoom()
    {
        // 현재 GameObject의 위치를 가져옴
        speed = -1f;
        yield return new WaitForSeconds(3f);

        // 이후 동작 (speed 재설정 등)
        speed = Originspeed;
    }
}
