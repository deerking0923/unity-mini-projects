using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragTest : MonoBehaviour
{
    /*
    float distance = 10;

    void OnMouseDrag()
    {
        print("Drag!!");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,
Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }*/

    float distance = 10;
    Vector3 offset;
    Vector2 dragRangeX = new Vector2(-2.58f, 2.58f);
    Vector2 dragRangeY = new Vector2(-3.54f, 2.86f);

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;

        objPosition.x = Mathf.Clamp(objPosition.x, dragRangeX.x, dragRangeX.y);
        objPosition.y = Mathf.Clamp(objPosition.y, dragRangeY.x, dragRangeY.y);

        transform.position = objPosition;
    }
   /* void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            // 플레이어 아웃 처리를 수행합니다.
            Debug.Log("플레이어가 장애물과 충돌했습니다!");
            // 여기서 아웃 처리 또는 게임 오버 등을 구현할 수 있습니다.
            SceneManager.LoadScene("EndingScene");
        }
    }*/
}
