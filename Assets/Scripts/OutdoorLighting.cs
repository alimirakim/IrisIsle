using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OutdoorLighting : MonoBehaviour
{
  DateTime now;
  [SerializeField] DateTimeEventChannelSO newHourEventChannel;
  [SerializeField] Volume volume;
  ColorAdjustments colorAdjustments;
  // [SerializeField] SplitToning splitToning;

  void OnEnable()
  {
    newHourEventChannel.OnEventRaised += UpdateTime;
  }

  void OnDisable()
  {
    newHourEventChannel.OnEventRaised -= UpdateTime;
  }


  void SetColorAdjustments(Color firstColor, Color secondColor, int firstSaturation, int secondSaturation, float weight)
  {
    volume.profile.TryGet(out colorAdjustments);
    {
      colorAdjustments.colorFilter.value = Color.Lerp(firstColor, secondColor, weight);
      colorAdjustments.saturation.value = Mathf.Lerp(firstSaturation, secondSaturation, weight);
      // Debug.Log("weight " + weight + " colorFilter " + colorAdjustments.colorFilter.value.ToString() + " saturation " + colorAdjustments.saturation.value);
    }
  }

  void UpdateTime(DateTime dt)
  {
    now = dt;

    float dawnHour = 6f;
    float morningHour = 8f;
    float noonHour = 13f;
    float duskHour = 18f;
    float midnightHour = 24f;

    bool isMorning = now.Hour >= dawnHour && now.Hour < noonHour; // 5-11
    bool isDay = now.Hour >= noonHour && now.Hour < duskHour;
    bool isEvening = now.Hour >= duskHour; //&& now.Hour < midnightHour;
    bool isNight = now.Hour == midnightHour || now.Hour < dawnHour;

    Color noFilterColor = new Color(1, 1, 1);
    Color nightFilterColor = new Color(0.25f, 0.25f, 0.7f);
    Color dawnFilterColor = new Color(1, 1, 0.7f);
    Color eveningFilterColor = new Color(1, 0.8f, 0.7f);

    if (isMorning)
    {
      SetColorAdjustments(dawnFilterColor, noFilterColor, -40, 0, CalculateWeight(morningHour, noonHour));
    }
    else if (isDay)
    {
      SetColorAdjustments(noFilterColor, eveningFilterColor, 0, 0, CalculateWeight(noonHour, duskHour));
    }
    else if (isEvening)
    {
      SetColorAdjustments(eveningFilterColor, nightFilterColor, 0, -20, CalculateWeight(duskHour, midnightHour));
    }
    else if (isNight)
    {
      float weight = now.Hour == midnightHour ? 1 : CalculateWeight(0, dawnHour);
      SetColorAdjustments(nightFilterColor, dawnFilterColor, -20, -40, weight);
    }

  }

  float CalculateWeight(float startHour, float endHour)
  {
    return (float)((now.Hour - startHour) / (endHour - startHour));
  }

}
