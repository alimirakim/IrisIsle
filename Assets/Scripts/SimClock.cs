using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimClock : GameClockBase
{
  DateTime now = new DateTime(1, 1, 1, 0, 0, 0);
  int secondsPerSec = 1;
  bool isPaused = false;

  public override DateTime Now()
  {
    return now;
  }

  void Start()
  {
    StartCoroutine(Tick());
  }

  IEnumerator Tick()
  {
    while (true)
    {
      if (!isPaused) now = now.AddSeconds(secondsPerSec);

      yield return new WaitForSeconds(1f);
    }
  }

  void ChangeSecondsPerSec(int seconds)
  {
    secondsPerSec = seconds;
  }


}
