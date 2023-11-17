using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBuilder : MonoBehaviour
{
  // [SerializeField] List<PlantSO> plants;
  [SerializeField] TimeSystem timeSystem;

  [SerializeField] List<TreeSO> trees;

  // [SerializeField] GameObject flowerPrefab;
  // [SerializeField] GameObject bushPrefab;
  [SerializeField] GameObject treePrefab;
  [SerializeField] GameObject pinePrefab;
  [SerializeField] GameObject palmPrefab;


  // Start is called before the first frame update
  void Start()
  {

    foreach (TreeSO treeData in trees)
    {

      // GameObject treePrefabVariant = treeData.GetTreeType() switch
      // {
      //   TreeTypes.Normal => treePrefab,
      //   TreeTypes.Pine => pinePrefab,
      //   TreeTypes.Palm => palmPrefab,
      //   _ => treePrefab // TODO throw error
      // };

      GameObject prefabTree = Instantiate(treePrefab, treeData.GetPosition(),
      UnityEngine.Quaternion.identity);
      prefabTree.GetComponent<Tree>().SetTreeData(treeData);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  void BuildTestMap()
  {
    // trees = new List<TreeSO>() {
    //   new Tree()
    // };

    // fill a 3x3 acre 16x16-tile square with grass
    // Fill surrounding acres with half-grass half-sand
    // Two sand acres get rock patches
    // Top row is half-grass half-rock
    // Fill the remaining with ocean water
    // Create a 

    // loop through grid locations. if 1. ground tile is grass and 2. items tile is empty
    // place then roll for a random chance to place tree.



    // fill a 3x3 acre 16x16-tile square with grass
    // for the next outer acre, there is 1 row filled minimum.
    // beyond, every column has a chance of extending by 1, remaining the same, or receding 1
    // with the chance to stay the same being 50%. doesn't extend beyond 6 tiles out.
    // the corners are skipped until the end, then filled with a rounded curve out
    // sand fills a minimum 6 rows and can extend up to 12 rows with the final rows being water.
    // Two sand acres are randomly chosen to have stone sections.
    // The back section is stone only.




  }
}
