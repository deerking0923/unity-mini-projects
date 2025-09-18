using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour
{
    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
}