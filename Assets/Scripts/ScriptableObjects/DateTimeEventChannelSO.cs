using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/DateTime Event Channel")]
public class DateTimeEventChannelSO : ScriptableObject
{
  public UnityAction<DateTime> OnEventRaised;

  public void RaiseEvent(DateTime dt)
  {
    OnEventRaised?.Invoke(dt);
  }
}
