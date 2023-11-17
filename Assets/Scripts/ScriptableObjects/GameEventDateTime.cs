using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventDateTime : ScriptableObject
{
  /// <summary>
  /// The list of listeners that this event will notify if it is raised.
  /// </summary>
  private readonly List<GameEventDateTimeListener> listeners = new List<GameEventDateTimeListener>();

  // public void Raise(DateTime dateTime)
  // {
  //   // Loops backwards in case a listener's response includes removing it from the list.
  //   for (int i = listeners.Count - 1; i >= 0; i--)
  //     listeners[i].OnEventRaised(dateTime);
  // }

  public void RegisterListener(GameEventDateTimeListener listener)
  {
    if (!listeners.Contains(listener)) listeners.Add(listener);
  }

  public void UnregisterListener(GameEventDateTimeListener listener)
  {
    if (listeners.Contains(listener)) listeners.Remove(listener);
  }
}
