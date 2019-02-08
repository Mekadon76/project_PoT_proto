using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    private Slider healthbar;
    private Slider SpeedSlider;
    private BoosterController boostercon;

    public float Health;
    public float BoosterChargeAmt;
    public float Booster;

    private void Awake()
    {
        healthbar = GameObject.Find("UIManager/Health").GetComponent<Slider>();
        SpeedSlider = GameObject.Find("UIManager/SpeedSlider").GetComponent<Slider>();
        boostercon = GameObject.Find("UIManager/Booster").GetComponent<BoosterController>();
    }

    void Start()
    {
        init();
    }

    void Update()
    {
        healthbar.value = Health;

        if(Health > healthbar.maxValue)
        {
            Health = healthbar.maxValue;
        }
        if(Health < 0)
        {
            Health = 0;
        }

        boostercon.BoosterFill = Booster;

        if(Booster > 100)
        {
            Booster = 100;
        }
    }

    private void FixedUpdate()
    {
        SliderHP();
        Booster += BoosterChargeAmt * Time.deltaTime;
    }

    //게이지값 초기화
    private void init()
    {
        SpeedSlider.value = 2;
        healthbar.maxValue = Health;
        healthbar.value = Health;
        boostercon.BoosterFill = 0;
    }

    void SliderHP()
    {
        switch (SpeedSlider.value)
        {
            case 0:
                HpGain(18);
                break;

            case 1:
                HpGain(8);
                break;

            case 2:
                break;

            case 3:
                HpGain(-10);
                break;

            case 4:
                HpGain(-20);
                break;
        }
    }

    void HpGain(float amount)
    {
        Health += amount * Time.deltaTime;
    }
}
