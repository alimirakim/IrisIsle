using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class SeasonalTileDataSO : ScriptableObject
{
  [field: SerializeField] public TileBase SpringTile { get; private set; }
  [field: SerializeField] public TileBase SummerTile { get; private set; }
  [field: SerializeField] public TileBase AutumnTile { get; private set; }
  [field: SerializeField] public TileBase WinterTile { get; private set; }
}
