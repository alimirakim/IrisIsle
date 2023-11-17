using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcasterScript : MonoBehaviour
{
  [SerializeField] DateTimeEventChannelSO dateTimeChannel;

  // Update is called once per frame
  void Update()
  {
    if (dateTimeChannel != null)
    {
      dateTimeChannel.RaiseEvent(DateTime.Now);
    }
  }
}
