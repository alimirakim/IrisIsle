using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

// using System.Numerics;
using UnityEngine;


// position
// tree type
// date planted
// datelastgrowth
// growthState
// SimulateElapsedTime
// 

public class TreeFruit : MonoBehaviour
{
  [SerializeField] GameObject miniFruitPrefab;
  [SerializeField] GameObject fruitPrefab;
  DateTime lastFruitedDateTime;
  [SerializeField] int hoursPerStage = 3;
  Tree tree;
  int fruitCount = 0;
  List<GameObject> fruits = new List<GameObject>();
  int maxFruitCount = 5;

  // Start is called before the first frame update
  void Start()
  {
    tree = GetComponent<Tree>();
    Debug.Log("starting...");
    Debug.Log(tree.GetIsFullyGrown());

    // TODO tree TimeSys isn't assigned on Start, causes null ref error if tree starts fully grown
    if (tree.GetIsFullyGrown())
    {
      if (lastFruitedDateTime == null)
        lastFruitedDateTime = tree.GetDateTimeFullyGrown();

      UpdateFruitCountAndLatestFruitedDateTime();

      if (fruitCount > 0)
      {
        for (int i = 0; i < fruitCount; i++)
          PopulateFruit(i);
      }

      StartCoroutine(MaintainFruitGrowth());
    }
  }

  void UpdateFruitCountAndLatestFruitedDateTime()
  {
    if (fruitCount == maxFruitCount) return;

    if (lastFruitedDateTime == null)
      lastFruitedDateTime = tree.GetDateTimeFullyGrown();

    TimeSpan timeFruiting = tree.TimeSys.Now() - lastFruitedDateTime;
    int fruitGrownCount = (int)(timeFruiting.TotalMinutes / hoursPerStage);
    int totalFruit = Math.Clamp(fruitGrownCount + fruitCount, 0, maxFruitCount);

    if (totalFruit == maxFruitCount)
    {
      lastFruitedDateTime = tree.TimeSys.Now();
      fruitCount = totalFruit;
    }
    else
    {
      DateTime accLastFruitedDateTime = lastFruitedDateTime;
      for (int i = 0; i < fruitCount; i++)
        accLastFruitedDateTime.AddHours(hoursPerStage);
      lastFruitedDateTime = accLastFruitedDateTime;
    }

    fruitCount = totalFruit;
  }

  public void DropFruit()
  {
    if (fruits.Count > 0)
    {
      Debug.Log(fruits.Count);
      Debug.Log("fruits shaking out!");

      if (fruits.Count == maxFruitCount)
        lastFruitedDateTime = tree.TimeSys.Now();
      fruitCount -= 1;
      Destroy(fruits[fruits.Count - 1]);
      Debug.Log(fruits.Count);
      Instantiate(
        fruitPrefab,
        new Vector3(tree.Position.x, tree.Position.y - 1, 0),
        Quaternion.identity
      );

    }

  }

  void PopulateFruit(int i)
  {
    float pd = 0.0625f;

    Vector3[] fruitPositions = {
      tree.Position,
      new Vector3(tree.Position.x - pd*3, tree.Position.y + pd*4, 0),
      new Vector3(tree.Position.x + pd*3, tree.Position.y + pd*4, 0),
      new Vector3(tree.Position.x - pd*5, tree.Position.y - pd, 0),
      new Vector3(tree.Position.x + pd*5, tree.Position.y - pd, 0),
    };
    GameObject fruit = Instantiate(miniFruitPrefab, fruitPositions[i], Quaternion.identity);
    Debug.Log("what is the instance fruit?");
    Debug.Log(fruit);
    Debug.Log(i);

    fruits.Add(fruit);
  }

  // trigger on event when tree is shook and has less than 5 fruit?
  public void StartMaintainFruitGrowth()
  {
    StartCoroutine(MaintainFruitGrowth());
  }

  IEnumerator MaintainFruitGrowth()
  {
    while (true)
    {

      if (tree.GetIsFullyGrown())
      {
        UpdateFruitCountAndLatestFruitedDateTime();
        Debug.Log("fruitGrown?");
        Debug.Log(fruitCount);
        if (fruits.Count < fruitCount)
          PopulateFruit(fruitCount - 1);
      }
      yield return new WaitForSeconds(1f);
    }
  }
}
