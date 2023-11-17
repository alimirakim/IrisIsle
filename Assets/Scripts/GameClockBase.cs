using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GameClockBase : MonoBehaviour
{
  public abstract DateTime Now();
}
