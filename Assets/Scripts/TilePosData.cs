public struct TilePosData
{
  public string TileId { get; }
  public int X { get; }
  public int Y { get; }

  public TilePosData(string tileId, int x, int y)
  {
    TileId = tileId;
    X = x;
    Y = y;
  }
}