using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Splines;

public class Runner : MonoBehaviour
{
    private UIManager uimanager;
    private Animator anim;


    private float DefaultSpeed;
    public float CurrentSpeed;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();

        DefaultSpeed = GetComponent<SplineFollower>().followSpeed;
    }

    private void Start()
    {

    }

    private void Update()
    {
        //배속 적용한 현재 속도 계산
        CurrentSpeed = DefaultSpeed * uimanager.CurrentMspeed;
        //현 속도와 배속 SplineFollower와 애니메이션에 적용
        GetComponent<SplineFollower>().followSpeed = CurrentSpeed;
        anim.SetFloat("RunMultiplier", uimanager.CurrentMspeed);
    }
}
