using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;

public class DayTimeController : MonoBehaviour
{
    float time;  
    [SerializeField] float timeScale = 60f;
    const float secondsInday = 86400;

    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color nightLightColor;
    [SerializeField] Color dayLightColor = Color.white;
    [SerializeField] Light2D globalLight;
    private int days;

    [SerializeField] Text text;

    float Hours
    {
        get { return time / 3600f; }
    }

    float Minutes {
        get { return time % 3600f / 60f; }
    }
    private void Update() {
        time += Time.deltaTime * timeScale;
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = hh.ToString("00") + ":" + mm.ToString("00");

        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;

        if (time > secondsInday) {
            NextDay();
        }
    }

    private void NextDay() {
        time = 0;
        days += 1;
    }
}
