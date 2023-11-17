using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SeasonSystem : MonoBehaviour
{
  public enum Seasons { None, Spring, Summer, Autumn, Winter }

  public Seasons currentSeason;

  [SerializeField] TimeSystem timeSystem;

  // TODO Consider grouping these in arrays, check Quiz game code
  [SerializeField] Tilemap groundTilemap;
  [SerializeField] RuleTile currentGrassTile;
  [SerializeField] RuleTile springGrassTile;
  [SerializeField] RuleTile summerGrassTile;
  [SerializeField] RuleTile autumnGrassTile;
  [SerializeField] RuleTile winterGrassTile;

  [SerializeField] Tilemap plantsTilemap;
  [SerializeField] Tile currentTreeTile;
  [SerializeField] Tile springTreeTile;
  [SerializeField] Tile summerTreeTile;
  [SerializeField] Tile autumnTreeTile;
  [SerializeField] Tile winterTreeTile;

  [SerializeField] Tile currentBushTile;
  [SerializeField] Tile springBushTile;
  [SerializeField] Tile summerBushTile;
  [SerializeField] Tile autumnBushTile;
  [SerializeField] Tile winterBushTile;

  [SerializeField] Tile currentPineTile;
  [SerializeField] Tile pineTile;
  [SerializeField] Tile winterPineTile;

  // Start is called before the first frame update
  void Start()
  {
    AdjustGrassTilesForSeason();

    // TODO Delete this
    // currentSeason = Seasons.Winter;
  }


  void AdjustGrassTilesForSeason()
  {
    TimeSystem.Season currentSeason = timeSystem.CurrentSeason;
    var seasonalTiles = new Dictionary<TimeSystem.Season, (RuleTile grassTile, Tile bushTile, Tile treeTile, Tile pineTile)>
      {
        { TimeSystem.Season.Spring, (springGrassTile, springBushTile, springTreeTile, pineTile) },
        { TimeSystem.Season.Summer, (summerGrassTile, summerBushTile, summerTreeTile, pineTile) },
        { TimeSystem.Season.Autumn, (autumnGrassTile, autumnBushTile, autumnTreeTile, pineTile) },
        { TimeSystem.Season.Winter, (winterGrassTile, winterBushTile, winterTreeTile, winterPineTile) },
      };

    var currentSeasonalTiles = seasonalTiles[currentSeason];

    if (currentGrassTile != currentSeasonalTiles.grassTile)
      groundTilemap.SwapTile(currentGrassTile, currentSeasonalTiles.grassTile);

    if (currentBushTile != currentSeasonalTiles.bushTile)
      plantsTilemap.SwapTile(currentBushTile, currentSeasonalTiles.bushTile);

    if (currentTreeTile != currentSeasonalTiles.treeTile)
      plantsTilemap.SwapTile(currentTreeTile, currentSeasonalTiles.treeTile);

    if (currentPineTile != currentSeasonalTiles.pineTile)
      plantsTilemap.SwapTile(currentPineTile, currentSeasonalTiles.pineTile);

  }

}
