using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ���� �ð�
    float currentTime;
    // ���� �ð�
    float createTime = 1f;
    // �� ����
    public GameObject enemyFactory;
    // �ּ� �ð�
    public float minTime = 2.0f;
    // �ִ� �ð�
    public float maxTime = 5.0f;

    void Start()
    {
        // �¾ �� ���� ���� �ð��� ����
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            // x ��ǥ�� �������� ����
            float randomX = UnityEngine.Random.Range(-2f, 2f); // minX�� maxX�� ���ϴ� x ��ǥ �����Դϴ�.

            // �� ���忡�� ���� �����Ѵ�
            GameObject enemy = Instantiate(enemyFactory);
            // x ��ǥ�� �������� �����Ͽ� �� ��ġ�� ���� ���´�.
            enemy.transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
            currentTime = 0;
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }

}
