using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoomManager : MonoBehaviour
{
    // 정적 변수 유지
    public static int cooling_grenade = 0;
    public static int electric_grenade = 0;
    public static int whirlwind_grenade = 0;

    // 인스펙터에서 할당할 게임 오브젝트들
    public GameObject IceBoom;
    public GameObject ElectricBoom;
    public GameObject WhirlwindBoom;

    // UI 버튼 컴포넌트들을 직접 연결
    public Button Bomb01Button;
    public Button Bomb02Button;
    public Button Bomb03Button;

    private void Start()
    {
        // 게임 시작 시 버튼 상태를 초기화합니다.
        UpdateButtons();
    }

    // 모든 폭탄 버튼의 상호작용 가능 상태를 업데이트하는 함수
    void UpdateButtons()
    {
        // Debug.Log를 추가하여 현재 점수 값을 확인합니다.
        // 유니티 콘솔 창에서 이 값을 직접 확인해 보세요.
        Debug.Log("현재 점수 - Num1: " + Num1.score + ", Num2: " + Num2.score + ", Num3: " + Num3.score + ", Num4: " + Num4.score + ", Num5: " + Num5.score);

        // 냉각 수류탄 버튼 활성화 조건
        bool coolingCondition = (Num1.score >= 1 && Num2.score >= 1 && Num5.score >= 1);
        Bomb01Button.interactable = coolingCondition;

        // 전기 수류탄 버튼 활성화 조건
        bool electricCondition = (Num2.score >= 1 && Num3.score >= 1 && Num5.score >= 1);
        Bomb02Button.interactable = electricCondition;

        // 회오리 수류탄 버튼 활성화 조건
        bool whirlwindCondition = (Num1.score >= 1 && Num3.score >= 1 && Num4.score >= 1);
        Bomb03Button.interactable = whirlwindCondition;
    }

    void Update()
    {
        // 매 프레임마다 UpdateButtons()를 호출하여 버튼 상태를 실시간으로 업데이트합니다.
        UpdateButtons();
    }

    public void cooling()
    {
        // 재료가 충분한지 다시 한번 확인하고, 충분할 경우에만 실행
        if (Num1.score >= 1 && Num2.score >= 1 && Num5.score >= 1)
        {
            Num1.score -= 1;
            Num2.score -= 1;
            Num5.score -= 1;

            Debug.Log("냉각 수류탄 발사!");

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

            Debug.Log("전기 수류탄 발사!");

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

            Debug.Log("회오리 수류탄 발사!");

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