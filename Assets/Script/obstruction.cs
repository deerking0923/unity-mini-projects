using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class obstruction : MonoBehaviour
{    // 이동속도
    public float speed = 3f;
    public float HP = 30f;
   // public float destroytime = 7;
    public float delay = 2f;
    int randomIndex = 0;
    //public AudioSource s;
    public AudioSource audioSource;
    public GameObject[] destroyedPrefabs;
    public Sprite[] randomSprites; // 랜덤으로 선택할 스프라이트 이미지 배열
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 컴포넌트
   /* public GameObject Bomb01;
    public GameObject Bomb02;
    public GameObject Bomb03;
   */
    Vector2 dir;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 스프라이트 배열에 랜덤한 이미지를 할당
        randomIndex = UnityEngine.Random.Range(0, randomSprites.Length);
        spriteRenderer.sprite = randomSprites[randomIndex];

        //Vector3 desiredScale = new Vector3(0.1f, 0.1f, 0.0f); // X, Y, Z 축의 스케일 값을 조정
        //transform.localScale = desiredScale;

        //Invoke("DestroyEnemy", destroytime);
    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (playerAttack.buffCat == 1) return;
            // 플레이어 아웃 처리를 수행합니다.
            Debug.Log("플레이어가 난파선과 충돌했습니다!");
            SceneManager.LoadScene("EndingScene");
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            DestroyEnemy();
        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            // 상대를 파괴한다
            Destroy(collision.gameObject);

            HP -= 10;
            // 자신을 파괴한다
            if (HP <= 0)
            {
                //s.Play();
                audioSource.Play();
                int r1 = UnityEngine.Random.Range(1, 6);
                int r2;
                while (true)
                {
                    r2 = UnityEngine.Random.Range(1, 6);
                    if (r1 != r2) break;
                }

                if (r1 == 1 || r2 == 1)
                {
                    //int n = UnityEngine.Random.Range(1, 3);
                    Num1.score += 1;
                }
                if (r1 == 2 || r2 == 2)
                {
                    //int n = UnityEngine.Random.Range(1, 3);
                    Num2.score += 1;
                }
                if (r1 == 3 || r2 == 3)
                {
                    //int n = UnityEngine.Random.Range(1, 3);
                    Num3.score += 1;
                }
                if (r1 == 4 || r2 == 4)
                {
                    //int n = UnityEngine.Random.Range(1, 3);
                    Num4.score += 1;
                }
                if (r1 == 5 || r2 == 5)
                {
                    //int n = UnityEngine.Random.Range(1, 3);
                    Num5.score += 1;
                }
                /*if (Num1.score >= 1 && Num2.score >= 1 && Num5.score >= 1)
                    Bomb01.SetActive(false);
                if (Num2.score >= 1 && Num3.score >= 1 && Num5.score >= 1)
                    Bomb02.SetActive(false);
                if (Num1.score >= 1 && Num3.score >= 1 && Num4.score >= 1)
                    Bomb03.SetActive(false);
                    //UpdateBombUI();*/
                GetComponent<BoxCollider2D>().enabled = false;
                //GetComponent<Image>().enabled = false;
                speed = 0;
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = false;
                ShowDestroyedImage(); // 파괴된 이미지 표시
            }
        }
    }
    GameObject destroyedImage;
    private void ShowDestroyedImage()
    {
        destroyedImage = Instantiate(destroyedPrefabs[randomIndex], transform.position, transform.rotation);
        StartCoroutine(DestroyImage(destroyedImage));
        
    }
    private IEnumerator DestroyImage(GameObject image)
    {
        Debug.Log("파괴전");
        yield return new WaitForSeconds(delay);
        Debug.Log("파괴후");
        Destroy(gameObject);
        Destroy(image); // 파괴된 이미지 제거
    }

}
