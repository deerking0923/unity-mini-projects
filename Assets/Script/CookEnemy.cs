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

        // ���� y ��ǥ�� 7 �̻��� ���
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
            Debug.Log("��������ź �۵�");
            StartCoroutine(IceBoom());
        }
        if (collision.gameObject.CompareTag("Electric"))
        {
            Debug.Log("�������ź �۵�");
            StartCoroutine(ElrctricBoom());
        }
        if (collision.gameObject.CompareTag("Wind"))
        {
            Debug.Log("ȸ��������ź �۵�");
            StartCoroutine(WindBoom());
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            DestroyEnemy();
        }
        if (collision.gameObject.CompareTag("player"))
        {
            if (playerAttack.buffCat == 1) return;
            // �÷��̾� �ƿ� ó���� �����մϴ�.
            Debug.Log("�÷��̾ ����� �浹�߽��ϴ�!");
            SceneManager.LoadScene("EndingScene");
        }

        if (collision.gameObject.CompareTag("bullet"))
        {
            // ��븦 �ı��Ѵ�
            Destroy(collision.gameObject);

            HP -= AttackDamage;
            // �ڽ��� �ı��Ѵ�
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
        // ���� GameObject�� ��ġ�� ������
        speed = -1f;
        yield return new WaitForSeconds(3f);

        // ���� ���� (speed �缳�� ��)
        speed = Originspeed;
    }
}
