using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterController : MonoBehaviour
{
    private BoosterHandle handle;
    private Text boostertext;

    [Range(0f,100f)]
    public float BoosterFill;

    private Image gauge1;
    private Image gauge2;
    private Image gauge3;

    private void Awake()
    {
        boostertext = GetComponentInChildren<Text>();

        handle = GameObject.Find("UIManager/Handle").GetComponent<BoosterHandle>();
        gauge1 = GameObject.Find("Booster/Gauge1").GetComponent<Image>();
        gauge2 = GameObject.Find("Booster/Gauge2").GetComponent<Image>();
        gauge3 = GameObject.Find("Booster/Gauge3").GetComponent<Image>();
    }

    private void Start()
    {
        //초기화
        //BoosterFill = 0f;
        //gauge1.fillAmount = 0f;
        //gauge2.fillAmount = 0f;
        //gauge3.fillAmount = 0f;
    }

    void Update()
    {

        //부스터 채우기 관련

        gauge1.fillAmount = BoosterFill * 0.04f;
        if (gauge1.fillAmount >= 1)
        {
            gauge2.fillAmount = (BoosterFill - 25) * 0.08f;
        }
        if (gauge1.fillAmount >= 1 && gauge2.fillAmount >=1)
        {
            gauge3.fillAmount = (BoosterFill - 37.5f) * 0.016f;
        }

        //부스터 감소 관련

        if (BoosterFill <37.5f)
        {
            gauge3.fillAmount = 0f;
        }
        if (BoosterFill < 25f)
        {
            gauge2.fillAmount = 0f;
        }

        //텍스트 표기
        boostertext.text = Mathf.Round(BoosterFill) + "<size=20>%</size>";
    }
}
