using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class TimeSystem : MonoBehaviour
{
  public enum Season { None, Spring, Summer, Autumn, Winter }
  public enum TimeOfDay { None, Dawn, Morning, Afternoon, /*LateNoon,*/ Evening, Dusk, Midnight, Night }

  [SerializeField] SerializableDateTime now = new SerializableDateTime(new DateTime(1, 1, 1, 12, 0, 0));
  [SerializeField] int timeSpeedIndex = 3;
  public Season CurrentSeason { get; private set; }
  bool isPaused = false;
  int[] timeSpeedOptions = {
    1, // realtime
    30, // 30sec/sec - 48min day
    60, // 1min/sec - 24min day
    120, // 2min/sec - 12min day
    
    // 600, // 10min/sec
    3600, // 1hr/sec
    14400, // 4hr/sec (6sec/day)
    86400 // 1day/sec
    };

  int newDayHour = 5;

  [SerializeField] DateTimeEventChannelSO newHourEventChannel;
  [SerializeField] DateTimeEventChannelSO newDayEventChannel;


  void Awake()
  {
    CurrentSeason = GetSeason(now.DateTime.Month);
    StartCoroutine(TickClock());
  }

  public void SetNow(DateTime dt)
  {
    now = new SerializableDateTime(dt);
  }

  public DateTime Now() => now.DateTime;

  IEnumerator TickClock()
  {
    while (true)
    {
      if (!isPaused)
      {
        SerializableDateTime oldTime = now;

        SerializableDateTime newTime = new SerializableDateTime(now.DateTime.AddSeconds(timeSpeedOptions[timeSpeedIndex]));
        now = newTime;
        if (oldTime.DateTime.Hour != now.DateTime.Hour) { newHourEventChannel.RaiseEvent(now.DateTime); }
        if (oldTime.DateTime.Day != now.DateTime.Day && oldTime.DateTime.Hour == newDayHour) { newDayEventChannel.RaiseEvent(now.DateTime); }
      }
      yield return new WaitForSeconds(1f);
    }
  }

  public void PauseTime()
  {
    Debug.Log("paused time");
    isPaused = true;
  }

  public void UnpauseTime()
  {
    Debug.Log("play time");
    isPaused = false;
  }

  public void ForwardOneDay()
  {
    now = new SerializableDateTime(now.DateTime.AddDays(1));
  }

  public void SpeedUpTime()
  {
    if (timeSpeedIndex + 1 < timeSpeedOptions.Length - 1)
      timeSpeedIndex += 1;
    Debug.Log("speed up " + timeSpeedIndex.ToString());
  }

  public void SlowDownTime()
  {
    if (timeSpeedIndex > 0)
      timeSpeedIndex -= 1;
    Debug.Log("slow down " + timeSpeedIndex.ToString());
  }


  Season GetSeason(int monthIndex)
  {
    return monthIndex switch
    {
      3 => Season.Spring,
      4 => Season.Spring,
      5 => Season.Spring,
      6 => Season.Summer,
      7 => Season.Summer,
      8 => Season.Summer,
      9 => Season.Autumn,
      10 => Season.Autumn,
      11 => Season.Autumn,
      12 => Season.Winter,
      1 => Season.Winter,
      2 => Season.Winter,
      _ => Season.None
    };
  }
}
