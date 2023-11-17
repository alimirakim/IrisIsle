using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
  /// <summary>
  /// The list of listeners that this event will notify if it is raised.
  /// </summary>
  private readonly List<GameEventListener> listeners = new List<GameEventListener>();

  public void Raise()
  {
    // Loops backwards in case a listener's response includes removing it from the list.
    for (int i = listeners.Count - 1; i >= 0; i--)
      listeners[i].OnEventRaised();
  }

  public void RegisterListener(GameEventListener listener)
  {
    if (!listeners.Contains(listener)) listeners.Add(listener);
  }

  public void UnregisterListener(GameEventListener listener)
  {
    if (listeners.Contains(listener)) listeners.Remove(listener);
  }
}
