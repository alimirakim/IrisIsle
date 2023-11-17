using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// int oneSecPerSec = 1;
// int tenSecPerSec = 10;
// int thirtySecPerSec = 30;
// int oneMinPerSec = 60;
// int tenMinPerSec = 60 * 10;
// int oneHrPerSec = 3600;

public class TimeSystemSO : ScriptableObject
{

  int secondsPerSec = 60;
  TimeSpan resetTime = new TimeSpan(3, 0, 0);


  DateTime now = new DateTime(1, 1, 1, 0, 0, 0);
  [field: SerializeField] public float SecondsPerSecond { get; private set; }

  void Awake()
  {
    // Load previous timestamp in save or load current time
    DateTime saveData = new DateTime(1, 9, 0);
    now = saveData;

    // StartCoroutine(TickXPerSecond());
  }

  public void ProceedNextDay() { now = now.AddDays(1); }

  IEnumerator TickXPerSecond()
  {
    while (true)
    {
      now = now.AddSeconds(secondsPerSec);
      yield return new WaitForSeconds(1f);
    }
  }

}
