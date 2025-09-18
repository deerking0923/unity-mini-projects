using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoomManager : MonoBehaviour
{
    // ���� ���� ����
    public static int cooling_grenade = 0;
    public static int electric_grenade = 0;
    public static int whirlwind_grenade = 0;

    // �ν����Ϳ��� �Ҵ��� ���� ������Ʈ��
    public GameObject IceBoom;
    public GameObject ElectricBoom;
    public GameObject WhirlwindBoom;

    // UI ��ư ������Ʈ���� ���� ����
    public Button Bomb01Button;
    public Button Bomb02Button;
    public Button Bomb03Button;

    private void Start()
    {
        // ���� ���� �� ��ư ���¸� �ʱ�ȭ�մϴ�.
        UpdateButtons();
    }

    // ��� ��ź ��ư�� ��ȣ�ۿ� ���� ���¸� ������Ʈ�ϴ� �Լ�
    void UpdateButtons()
    {
        // Debug.Log�� �߰��Ͽ� ���� ���� ���� Ȯ���մϴ�.
        // ����Ƽ �ܼ� â���� �� ���� ���� Ȯ���� ������.
        Debug.Log("���� ���� - Num1: " + Num1.score + ", Num2: " + Num2.score + ", Num3: " + Num3.score + ", Num4: " + Num4.score + ", Num5: " + Num5.score);

        // �ð� ����ź ��ư Ȱ��ȭ ����
        bool coolingCondition = (Num1.score >= 1 && Num2.score >= 1 && Num5.score >= 1);
        Bomb01Button.interactable = coolingCondition;

        // ���� ����ź ��ư Ȱ��ȭ ����
        bool electricCondition = (Num2.score >= 1 && Num3.score >= 1 && Num5.score >= 1);
        Bomb02Button.interactable = electricCondition;

        // ȸ���� ����ź ��ư Ȱ��ȭ ����
        bool whirlwindCondition = (Num1.score >= 1 && Num3.score >= 1 && Num4.score >= 1);
        Bomb03Button.interactable = whirlwindCondition;
    }

    void Update()
    {
        // �� �����Ӹ��� UpdateButtons()�� ȣ���Ͽ� ��ư ���¸� �ǽð����� ������Ʈ�մϴ�.
        UpdateButtons();
    }

    public void cooling()
    {
        // ��ᰡ ������� �ٽ� �ѹ� Ȯ���ϰ�, ����� ��쿡�� ����
        if (Num1.score >= 1 && Num2.score >= 1 && Num5.score >= 1)
        {
            Num1.score -= 1;
            Num2.score -= 1;
            Num5.score -= 1;

            Debug.Log("�ð� ����ź �߻�!");

            IceBoom.SetActive(true);

            StartCoroutine(IceBoomStart());
        }
    }

    private IEnumerator IceBoomStart()
    {
        yield return new WaitForSeconds(2f);
        IceBoom.SetActive(false);
    }

    public void electric()
    {
        if (Num2.score >= 1 && Num3.score >= 1 && Num5.score >= 1)
        {
            Num2.score -= 1;
            Num3.score -= 1;
            Num5.score -= 1;

            Debug.Log("���� ����ź �߻�!");

            ElectricBoom.SetActive(true);
            StartCoroutine(electricBoomStart());
        }
    }

    private IEnumerator electricBoomStart()
    {
        yield return new WaitForSeconds(2f);
        ElectricBoom.SetActive(false);
    }

    public void whirlwind()
    {
        if (Num1.score >= 1 && Num3.score >= 1 && Num4.score >= 1)
        {
            Num1.score -= 1;
            Num3.score -= 1;
            Num4.score -= 1;

            Debug.Log("ȸ���� ����ź �߻�!");

            WhirlwindBoom.SetActive(true);
            StartCoroutine(whirlwindBoomStart());
        }
    }

    private IEnumerator whirlwindBoomStart()
    {
        yield return new WaitForSeconds(2f);
        WhirlwindBoom.SetActive(false);
    }
}