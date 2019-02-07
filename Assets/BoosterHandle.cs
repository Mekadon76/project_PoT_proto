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

    private bool isDraging;
    private bool isRotating;
    private bool isLineDrag;
    private bool checkPoint;
    private float angle;

    private Vector3 defaultPos;

    private void Start()
    {
        defaultPos = handle.transform.position;
    }

    void Update()
    {
        DragRotateHandle();
        DragLinerHandle();
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

    void DragRotateHandle()
    {
        if (isDraging)
        {
            dir = (Input.mousePosition - handle.transform.position);
            dist = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);

            angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

            // -180에서 180까지 표기되는 각도를 0에서 360으로 변경
            angle = (angle > 0) ? angle : angle + 360;

            //직선드래그
            if (angle >= 180 && angle<= 240 && dist >= 180)
            {
                isRotating = false;
                isLineDrag = true;
            }

            //회전드래그
            if (isRotating)
            {
                handle.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.back);
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

    void DragLinerHandle()
    {
        if(isLineDrag)
        {
            handle.transform.rotation = Quaternion.Euler(0, 0, -90);
            handle.transform.position = new Vector3 (Input.mousePosition.x+21, 179, handle.transform.position.z);
        }
    }

    void ResetDefaultPos()
    {
        if (!isDraging)
        {
            Vector3 startposition = new Vector3(handle.transform.position.x, handle.transform.position.y, handle.transform.position.z);
            Vector3 targetposition = new Vector3(defaultPos.x, handle.transform.position.y, handle.transform.position.z);
            handle.transform.position = Vector3.Lerp(handle.transform.position, targetposition, Time.deltaTime*12);
        }
    }
}
