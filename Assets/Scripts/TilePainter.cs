using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    [SerializeField] Tile springGrassTile;
    [SerializeField] Vector3Int position;
    [SerializeField] Tilemap tilemap;
    
    [ContextMenu("Paint")]
    void Paint()
    {
      tilemap.SetTile(position, springGrassTile);
      Debug.Log("GRID");
      Debug.Log(tilemap.layoutGrid);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
