using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : ScriptableObject
{
  [field: SerializeField] public DateTime TimeLastSaved { get; set; }
  [field: SerializeField] public string PlayerName { get; set; }
  [field: SerializeField] public string MapName { get; set; }

  public DateTime TimeFileCreated { get; private set; }
  public DateTime PlayerBirthday { get; private set; }

  public List<TilePosData> BlockTilemapData { get; set; }
  public List<TilePosData> GrassTilemapData { get; set; }

  // Inventory: Clothes, Tools, Items, Food

  public void SetSaveDateTime(DateTime dt) => TimeLastSaved = dt;
}
