using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileId : ScriptableObject
{
  [field: SerializeField] public TileBase Tile { get; private set; }
  public string Id { get; private set; }
}
