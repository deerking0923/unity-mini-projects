using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 현재 시간
    float currentTime;
    // 일정 시간
    float createTime = 1f;
    // 적 공장
    public GameObject enemyFactory;
    // 최소 시간
    public float minTime = 2.0f;
    // 최대 시간
    public float maxTime = 5.0f;

    void Start()
    {
        // 태어날 때 적의 생성 시간을 설정
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            // x 좌표를 랜덤으로 설정
            float randomX = UnityEngine.Random.Range(-2f, 2f); // minX와 maxX는 원하는 x 좌표 범위입니다.

            // 적 공장에서 적을 생성한다
            GameObject enemy = Instantiate(enemyFactory);
            // x 좌표를 랜덤으로 설정하여 내 위치에 갖다 놓는다.
            enemy.transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
            currentTime = 0;
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }

}
