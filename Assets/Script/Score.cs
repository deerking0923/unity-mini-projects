using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static UnityEvent<int> OnScoreReached = new UnityEvent<int>();

    public static void UpdateScore(int newScore)
    {
        score = newScore;
        OnScoreReached.Invoke(score);
    }
    //public static int firstAttack = 1; //버프를 위한 첫번째 공격 가려내기용...
   //public static int score = 0;
    public static int Bestscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(score);
        if (Bestscore < score) Bestscore = score;
        GetComponent<TextMeshProUGUI>().text =  score.ToString();
    }
}
