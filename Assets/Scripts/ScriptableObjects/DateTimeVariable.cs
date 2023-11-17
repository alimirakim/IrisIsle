using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DateTimeVariable : ScriptableObject
{
  [SerializeField] int year = 1;
  [SerializeField] int month = 1;
  [SerializeField] int day = 1;
  [SerializeField] int hour = 0;
  [SerializeField] int minute = 0;
  [SerializeField] int second = 0;

  public DateTime Value
  {
    get => new DateTime(
      Math.Clamp(year, 0, 10000),
      Math.Clamp(month, 1, 12),
      Math.Clamp(day, 1, 31),
      Math.Clamp(hour, 0, 23),
      Math.Clamp(minute, 0, 59),
      Math.Clamp(second, 0, 59)
      );
  }
}
