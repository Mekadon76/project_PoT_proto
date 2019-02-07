using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Slider SpeedSlider;

    private float MultiplyPerSliderLevel;

    //Min and Max of Multiply Speed
    public float Min_MSpeed;
    public float Max_MSpeed;

    public float CurrentMspeed;

    private void Awake()
    {
        SpeedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
        MultiplyPerSliderLevel = (Max_MSpeed - Min_MSpeed) / SpeedSlider.maxValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMspeed = Min_MSpeed + (MultiplyPerSliderLevel * (SpeedSlider.value));
    }
}
