using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    public float speed;
    public Sprite newSprite; // ���ο� �̹����� ���� ����

    private Sprite originalSprite; // ���� �̹����� ������ ����
    // Start is called before the first frame update
    void Start()
    {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
        //Invoke("DestroyBullet", 4);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("highwall"))
        {
            DestroyBullet();
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (playerAttack.buffCat == 1) GetComponent<SpriteRenderer>().sprite = newSprite;
        else GetComponent<SpriteRenderer>().sprite = originalSprite;
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
