using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // public playerAttack player;
    //  public GameObject BuffEffect;
    // �̵��ӵ�
    public static float AttackDamage = 10f;
    public float speed = 3f;
    public float HP = 30f;
    private Animator animator;
    float Originspeed = 3f;
    //public float destroytime = 5;
    //public GameObject EndingSet;

    Vector2 dir;
    void Start()
    {
        Originspeed = speed;
        animator = GetComponent<Animator>();
        //Invoke("DestroyEnemy", destroytime);

        /*
        // 0���� 9������ �� �߿� �ϳ��� �����ϰ� �����´�.
        int randValue = UnityEngine.Random.Range(0, 10);
        // ���� 4���� �۴ٸ� �÷��̾� ����
        if (randValue < 4)
        {
            // �÷��̾ ã�� target�� ����
            GameObject target = GameObject.Find("player");
            // ������ ���Ѵ�.
            dir = ((Vector2)target.transform.position - (Vector2)transform.position).normalized;
        }
        // �ƴ϶�� �Ʒ� ����
        else
        {
            dir = Vector2.down;
        }
        */
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
                Destroy(gameObject);
                Score.score += 10;
            }
        }
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
