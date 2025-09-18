using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerAttack : MonoBehaviour
{
    public GameObject BuffEffect;
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;
    private int first = 1;
    public static int buffCat = 0;

    void Start()
    {
        Score.OnScoreReached.AddListener(OnScoreReachedHandler);
    }

    private void OnScoreReachedHandler(int score)
    {
        if (score == 500) first = 0;
        // 스코어가 30의 배수가 될 때 코루틴 실행
        if (score % 500 == 0 && first == 0)
        {
            StartCoroutine(BuffOnCoroutine());
        }
    }

    private IEnumerator BuffOnCoroutine()
    {
        BuffEffect.SetActive(true);
        Enemy.AttackDamage = 20f;
        buffCat = 1;
        yield return new WaitForSeconds(10f);
        buffCat = 0;
        Enemy.AttackDamage = 10f;
        BuffEffect.SetActive(false);
    }

    private void Update()
    {
        if (curtime <= 0)
        {
            Instantiate(bullet, pos.position, transform.rotation);
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}