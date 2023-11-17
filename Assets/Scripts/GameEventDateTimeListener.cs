using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventDateTimeListener : MonoBehaviour
{
  [Tooltip("Event to register with.")]
  public GameEventDateTime Event;
  [Tooltip("Response to invoke when Event is raised.")]
  public UnityEvent Response;

  private void OnEnable()
  {
    Event.RegisterListener(this);
  }

  private void OnDisable()
  {
    Event.RegisterListener(this);
  }

  public void OnEventRaised(DateTime dateTime)
  {
    // Response.Invoke(dateTime);
  }
}
