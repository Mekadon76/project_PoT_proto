using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterHandle : MonoBehaviour
{
    public Image handle;

    Vector2 dir;
    float dist;
    float check;

    private bool isDraging = false;
    private bool isRotating = false;
    private bool isLineDrag = false;

    private bool checkPoint;
    private float angle;

    private Vector3 defaultPos;

    private void Start()
    {
        defaultPos = handle.transform.position;
    }

    void Update()
    {
        DragHandle();
        ResetDefaultPos();
    }

    public void BeginDrag()
    {
        isDraging = true;
        isRotating = true;
    }

    public void EndDrag()
    {
        isDraging = false;
        if (isLineDrag)
        {
            isLineDrag = false;
        }
    }

    void DragHandle()
    {
        if (isDraging)
        {
            dir = (Input.mousePosition - handle.transform.position);
            dist = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);

            angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

            // -180에서 180까지 표기되는 각도를 0에서 360으로 변경
            angle = (angle > 0) ? angle : angle + 360;

            //각도방식 직선드래그 탐지
            if (angle >= 180 && angle <= 250 && dist >= 100)
            {
                isRotating = false;
                isLineDrag = true;
            }

            //회전드래그
            if (isRotating)
            {
                handle.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.back);
            }

            //직선드래그
            //실수 273.49는 오브젝트 로컬포지션 왼쪽 한계선, 566.42는 오브젝트 로컬포지션 오른쪽 한계선 

            if (isLineDrag && GetComponent<RectTransform>().localPosition.x > 273.49f 
                && GetComponent<RectTransform>().localPosition.x < 566.42f)
            {
                handle.transform.rotation = Quaternion.Euler(0, 0, -90);
                handle.transform.position = new Vector3(Input.mousePosition.x, handle.transform.position.y, handle.transform.position.z);
            }

            if (GetComponent<RectTransform>().localPosition.x < 273.49f)
            {
                //수동으로 로컬포지션 고정 위치 오프셋 잡아줌
                handle.transform.localPosition = new Vector3(272.1041f, -240.6f, handle.transform.position.z);
            }

            if (GetComponent<RectTransform>().localPosition.x > 566.42f)
            {
                //수동으로 로컬포지션 고정 위치 오프셋 잡아줌
                handle.transform.localPosition = new Vector3(566.42f, -240.6f, handle.transform.position.z);
            }

        }

        //한바퀴 돌리는 것을 감지
        if (angle > 160 && angle < 200)
        {
            checkPoint = true;
        }
        if (angle > 350 && checkPoint)
        {
            checkPoint = false;
            Debug.Log("Score++");
        }
    }

    void ResetDefaultPos()
    {
        if (!isDraging)
        {
            Vector3 targetposition = new Vector3(defaultPos.x, handle.transform.position.y, handle.transform.position.z);
            handle.transform.position = Vector3.Lerp(handle.transform.position, targetposition, Time.deltaTime*8);
        }
    }
}
