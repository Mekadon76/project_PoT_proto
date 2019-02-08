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
    public float BoostingSpeed;
    public float BoostingTime;

    public bool isBoosting;
    //public GameObject boosterparticle;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();

        DefaultSpeed = GetComponent<SplineFollower>().followSpeed;
    }

    private void Start()
    {
        isBoosting = false;
    }

    private void Update()
    {
        if (!isBoosting)
        {
            //배속 적용한 현재 속도 계산
            CurrentSpeed = DefaultSpeed * uimanager.CurrentMspeed;
            //현 속도와 배속 SplineFollower와 애니메이션에 적용
            anim.SetFloat("RunMultiplier", uimanager.CurrentMspeed);
        }
        GetComponent<SplineFollower>().followSpeed = CurrentSpeed;

        if (isBoosting)
        {
            StartCoroutine(BoosterOn());
        }
    }

    public IEnumerator BoosterOn()
    {
        CurrentSpeed = DefaultSpeed * BoostingSpeed;
        anim.SetFloat("RunMultiplier", BoostingSpeed);
        //boosterparticle.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(BoostingTime);
        //boosterparticle.GetComponent<ParticleSystem>().Stop();
        isBoosting = false;
    }
}
