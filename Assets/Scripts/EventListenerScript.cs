using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerScript : MonoBehaviour
{

  [SerializeField] DateTimeEventChannelSO dateTimeChannel;
  void Awake()
  {

  }

  void OnEnable()
  {
    dateTimeChannel.OnEventRaised += UpdateTime;
  }

  void OnDisable()
  {
    dateTimeChannel.OnEventRaised -= UpdateTime;
  }

  void UpdateTime(DateTime dt)
  {
  }
}
