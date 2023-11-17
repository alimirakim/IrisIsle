using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemClock : GameClockBase
{
  public override DateTime Now() => DateTime.Now;
}
