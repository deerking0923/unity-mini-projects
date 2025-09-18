using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Num4 : MonoBehaviour
{
    public static int score = 0;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
