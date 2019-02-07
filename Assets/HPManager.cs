using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    private Slider healthbar;
    private Slider SpeedSlider;

    public int Health;
    public float HPtimer;

    // Start is called before the first frame update

    private void Awake()
    {
        healthbar = GameObject.Find("UIManager/Health").GetComponent<Slider>();
        SpeedSlider = GameObject.Find("UIManager/SpeedSlider").GetComponent<Slider>();

    }

    void Start()
    {

        init();
    }

    // Update is called once per frame
    void Update()
    {
        SliderHP();
    }


    private void init()
    {
        healthbar.maxValue = Health;
        healthbar.value = Health;
    }

    void SliderHP()
    {
        bool IsHPchanged = false;

        if (!IsHPchanged)
        {
            switch (SpeedSlider.value)
            {
                case 0:
                    print("2");
                    StartCoroutine(HPChange(2));
                    IsHPchanged = true;
                    break;
                case 1:
                    print("1");
                    StartCoroutine(HPChange(1));
                    IsHPchanged = true;
                    break;
                case 2:
                    IsHPchanged = true;
                    break;
                case 3:
                    print("-1");
                    StartCoroutine(HPChange(-1));
                    IsHPchanged = true;
                    break;
                case 4:
                    print("-2");
                    StartCoroutine(HPChange(-2));
                    IsHPchanged = true;
                    break;
            }
        }
    }

    IEnumerator HPChange(int a)
    {
            healthbar.value += a;
            Debug.Log(a + "만큼 닳고 있습니다!");
            yield return new WaitForSeconds(HPtimer);
    }
}
