using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTree : MonoBehaviour, IInteractibleObject
{
  Tree tree;
  [SerializeField] GameObject fruitPrefab;
  [SerializeField] int hoursPerFruit = 3;
  [SerializeField] List<GameObject> fruits;

  [SerializeField] DateTime dateTimeStartFruiting;

  // Start is called before the first frame update
  // void Start()
  // {
  //   tree = GetComponent<Tree>();
  //   if (tree.GetIsFullyGrown()) PopulateFruit();
  // }

  // IEnumerator MaintainFruitGrowth()
  // {

  // }

  // void PopulateFruit()
  // {
  //   float pd = 0.0625f;
  //   Vector3 treePos = tree.GetPosition();

  //   Vector3[] fruitPositions = {
  //       treePos,
  //       new Vector3(treePos.x - pd*3, treePos.y + pd*4, 0),
  //       new Vector3(treePos.x + pd*3, treePos.y + pd*4, 0),
  //       new Vector3(treePos.x - pd*5, treePos.y - pd, 0),
  //       new Vector3(treePos.x + pd*5, treePos.y - pd, 0),
  //     };
  //   for (int i = 0; i < fruits.Count; i++)
  //   {
  //     Instantiate(fruitPrefab, fruitPositions[i], Quaternion.identity);
  //   }
  // }

  public void Interact()
  {

  }

}
