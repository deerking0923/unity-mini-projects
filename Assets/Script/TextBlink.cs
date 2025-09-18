using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class TextBlink : MonoBehaviour
{
    public float delay;
    private TextMeshProUGUI titleText;

    void Awake()
    {
        titleText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        float alpha = 1f;
        float addVal;
        bool flag = true;
        while (true)
        {
            addVal = Time.deltaTime * (1f / delay);
            if (flag) addVal = -addVal;
            alpha += addVal;
            titleText.color = new Color(222f, 122f, 111f, alpha);
            if (alpha > 0.999f || alpha <= 0f) flag = !flag;
            yield return null;
        }
    }

}
