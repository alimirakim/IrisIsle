using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
#if UNITY_EDITOR
  [Multiline]
  public string DeveloperDescription = "";
#endif

  public float value;

  public void SetValue(float literalValue)
  {
    value = literalValue;
  }

  public void SetValue(FloatVariable variable)
  {
    value = variable.value;
  }

  public void Add(float amount)
  {
    value += amount;
  }

  public void Add(FloatVariable amount)
  {
    value += amount.value;
  }
}
