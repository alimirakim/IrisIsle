using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapManager : MonoBehaviour
{
  public static MapManager instance;
  [SerializeField] TimeSystem timeSystem;
  [SerializeField] Tilemap blockTilemap;
  [SerializeField] Grid grid;
  [SerializeField] List<SeasonalTileDataSO> seasonalTileData;
  Dictionary<TileBase, SeasonalTileDataSO> dataFromSeasonalTiles;
  List<TileId> tiles = new List<TileId>();

  // Youtube: Edit, Save, and Load Unity Tilemaps At Runtime! https://www.youtube.com/watch?v=snUe2oa_iM0

  void Awake()
  {
    if (instance == null) instance = this;
    else Destroy(this);
  }

  Vector3Int GetTilePos(TilePosData tileData) => new Vector3Int(tileData.X, tileData.Y, 0);

  TileBase GetTile(TilePosData tileData) => tiles.Find(t => t.name == tileData.TileId).Tile;

  public List<TilePosData> GetBlockTilemapData() => GetTilemapData(blockTilemap);

  public List<TilePosData> GetTilemapData(Tilemap map)
  {
    BoundsInt bounds = map.cellBounds;
    List<TilePosData> mapData = new List<TilePosData>();

    for (int x = bounds.min.x; x < bounds.max.x; x++)
    {
      for (int y = bounds.min.y; y < bounds.max.y; y++)
      {
        TileBase currentTile = map.GetTile(new Vector3Int(x, y, 0));
        TileId currentTileId = tiles.Find(t => t.Tile == currentTile);

        if (currentTileId != null)
        {
          mapData.Add(new TilePosData(currentTileId.Id, x, y));
        }
      }
    }

    return mapData;
    // string json = JsonUtility.ToJson(mapData, true);
    // File.WriteAllText(Application.dataPath + "/mapData.json", json);

  }

  public void LoadLevel(List<TilePosData> tilemapData)
  {
    // string json = File.ReadAllText(Application.dataPath + "/mapData.json");
    // List<TilePosData> tilemapData = JsonUtility.FromJson<List<TilePosData>>(json);

    blockTilemap.ClearAllTiles();

    for (int i = 0; i < tilemapData.Count; i++)
    {
      Vector3Int tilePos = GetTilePos(tilemapData[i]);
      TileBase tile = GetTile(tilemapData[i]);
      blockTilemap.SetTile(tilePos, tile);
    }
  }

  public void SetBlockTile(TilePosData tileData)
  {
    blockTilemap.SetTile(GetTilePos(tileData), GetTile(tileData));
  }


  void Start()
  {
    dataFromSeasonalTiles = new Dictionary<TileBase, SeasonalTileDataSO>();

    foreach (var tileData in seasonalTileData)
    {
      dataFromSeasonalTiles.Add(tileData.SpringTile, tileData);
    }

    AdjustTilesForSeason();
  }

  // TODO Add OnNewSeason event listener

  void AdjustTilesForSeason()
  {
    print("hmmm");
    print(timeSystem.CurrentSeason);
    Tilemap[] tilemaps = grid.GetComponentsInChildren<Tilemap>();
    foreach (var tilemap in tilemaps)
    {
      foreach (var tileData in seasonalTileData)
      {
        TileBase newSeasonTile = timeSystem.CurrentSeason switch
        {
          TimeSystem.Season.Spring => tileData.SpringTile,
          TimeSystem.Season.Summer => tileData.SummerTile,
          TimeSystem.Season.Autumn => tileData.AutumnTile,
          TimeSystem.Season.Winter => tileData.WinterTile,
          _ => tileData.SpringTile
        };
        print(newSeasonTile);
        tilemap.SwapTile(tileData.SpringTile, newSeasonTile);
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector3Int gridPosition = blockTilemap.WorldToCell(mousePosition);

      TileBase clickedTile = blockTilemap.GetTile(gridPosition);

      print("At position " + gridPosition + " there is a " + clickedTile);
    }
  }
}
