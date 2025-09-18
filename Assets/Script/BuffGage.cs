using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffGage : MonoBehaviour
{
    [SerializeField]
    private Slider Buffbar;

    private float max = 500;
    private float cur = 1;
    // Start is called before the first frame update
    void Start()
    {
        Buffbar.value = (float)cur / (float)max;   
    }

    // Update is called once per frame
    void Update()
    {
        cur = Score.score % 500;
        HandleHp();
    }
    private void HandleHp()
    {
        Buffbar.value = Mathf.Lerp(Buffbar.value, (float)cur / (float)max, Time.deltaTime * 10);
    }
}
