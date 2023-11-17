using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FloatReference
{
  public bool useLiteral = true;
  public float literalValue;
  public FloatVariable variable;

  public FloatReference()
  { }

  public FloatReference(float value)
  {
    useLiteral = true;
    literalValue = value;
  }

  public float Value
  {
    get => useLiteral ? literalValue : variable.value;
  }

  public static implicit operator float(FloatReference reference)
  {
    return reference.Value;
  }
}
