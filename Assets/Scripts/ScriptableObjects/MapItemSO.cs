using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItemSO : MonoBehaviour
{
  [field: SerializeField] public GameObject PrefabType { get; set; }
  [field: SerializeField] public Vector2 Position { get; set; }

}
