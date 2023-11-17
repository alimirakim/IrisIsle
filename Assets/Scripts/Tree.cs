using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TreeTypes { None, Normal, Pine, Palm, }
public enum TreeFruitTypes { None, Apple, Pear, Peach, Orange, Cherry, }

/*  */
public class Tree : MonoBehaviour, IInteractibleObject
{
  [field: SerializeField] public TimeSystem TimeSys { get; private set; }
  TreeSO treeData;
  [SerializeField] AudioClip shakeSFX;
  [SerializeField] Sprite[] growthSprites;
  [SerializeField] Sprite springSprite;
  [SerializeField] Sprite summerSprite;
  [SerializeField] Sprite autumnSprite;
  [SerializeField] Sprite winterSprite;
  Dictionary<TimeSystem.Season, Sprite> seasonalSprites;
  [SerializeField] Sprite choppedSprite;
  // [SerializeField] Vector3 position;
  [SerializeField] DateTime dateTimePlanted;
  // [SerializeField] DateTime dateTimeStartFruiting;
  // [SerializeField] GameObject fruitPrefab;
  [SerializeField] int health = 3;
  [SerializeField] int daysPerStage = 3;
  // [SerializeField] int hoursPerFruit = 3;
  // [SerializeField] List<GameObject> fruits;
  [SerializeField] TreeTypes treeType = TreeTypes.None;
  SpriteRenderer spriteRenderer;
  public UnityEvent shakeTreeEvent;
  public UnityEvent hasFullyGrownEvent;


  public Vector3 Position { get; private set; }

  public TreeTypes GetTreeType() => treeType;

  void Start()
  {
    seasonalSprites = new Dictionary<TimeSystem.Season, Sprite>{
      {TimeSystem.Season.Spring, springSprite},
      {TimeSystem.Season.Summer, summerSprite},
      {TimeSystem.Season.Autumn, autumnSprite},
      {TimeSystem.Season.Winter, winterSprite},
    };

    spriteRenderer = GetComponent<SpriteRenderer>();
    Position = GetComponent<Transform>().position;
    dateTimePlanted = TimeSys.Now(); // TODO Remove after testing
    // dateTimePlanted = treeData.GetDateTimePlanted; 
    UpdateSpriteGrowth();
    if (health == 0) UpdateSpriteIfChopped();
    else StartCoroutine(MaintainSpriteGrowth());
  }

  public void SetTreeData(TreeSO data) => treeData = data;
  public void SetTimeSystem(TimeSystem ts) => TimeSys = ts;

  public bool GetIsFullyGrown() => GetGrowthIndex() == growthSprites.Length - 1 ? true : false;

  int GetGrowthIndex()
  {
    Debug.Log("growthSprites?");
    Debug.Log(TimeSys.Now());
    Debug.Log(dateTimePlanted);
    TimeSpan timeSincePlanted = TimeSys.Now() - dateTimePlanted;
    int growthState = (int)timeSincePlanted.TotalDays / daysPerStage;
    // int growthState = timeSincePlanted.Hours / hoursPerStage;

    Debug.Log(timeSincePlanted);
    Debug.Log(growthState);
    int growthIndex = growthState >= growthSprites.Length ? growthSprites.Length - 1 : growthState;
    Debug.Log(growthIndex);
    return growthIndex;
  }

  public DateTime GetDateTimeFullyGrown()
  {

    return dateTimePlanted.AddMinutes(daysPerStage * (growthSprites.Length - 1));
  }

  // int GetFruitCount()
  // {
  //   TimeSpan timeSinceStartFruiting = DateTime.Now - dateTimeStartFruiting;
  //   int fruitGrown = timeSinceStartFruiting.Seconds / hoursPerFruit;
  //   // int fruitGrown = timeSinceStartFruiting.Hours / hoursPerFruit;
  //   return fruitGrown;
  // }

  void UpdateSpriteGrowth() => spriteRenderer.sprite = growthSprites[GetGrowthIndex()];

  IEnumerator MaintainSpriteGrowth()
  {
    while (true)
    {
      spriteRenderer.sprite = growthSprites[GetGrowthIndex()];
      if (GetIsFullyGrown())
      {
        hasFullyGrownEvent.Invoke();
        spriteRenderer.sprite = seasonalSprites[TimeSys.CurrentSeason];
        // PopulateFruit();
        yield break;
      }

      yield return new WaitForSeconds(1f);
    }
  }



  // void PopulateFruit()
  // {
  //   float pd = 0.0625f;

  //   Vector3[] fruitPositions = {
  //     position,
  //     new Vector3(position.x - pd*3, position.y + pd*4, 0),
  //     new Vector3(position.x + pd*3, position.y + pd*4, 0),
  //     new Vector3(position.x - pd*5, position.y - pd, 0),
  //     new Vector3(position.x + pd*5, position.y - pd, 0),
  //   };
  //   foreach (Vector3 pos in fruitPositions)
  //   {
  //     Instantiate(fruitPrefab, pos, Quaternion.identity);
  //   }
  // }

  // IEnumerator GrowFruit()
  // {
  //   while (true)
  //   {
  //     Instantiate(fruitPrefab, position, Quaternion.identity);
  //   }
  // }

  void UpdateSpriteIfChopped()
  {

    if (health == 0) spriteRenderer.sprite = choppedSprite;
  }

  public void Interact()
  {
    Debug.Log("shaking!");
    GetComponent<AudioSource>().PlayOneShot(shakeSFX);
    shakeTreeEvent.Invoke();
    // dateTimeStartFruiting = DateTime.Now;
    // fruits = new List<GameObject>();
  }

  void ReduceHealth(int damagePoints)
  {
    health = Math.Max(health - damagePoints, 0);
    UpdateSpriteIfChopped();
  }

  // public bool GetIsTouchingPlayer() => isTouchingPlayer;

  //  private void OnCollisionEnter2D(Collision2D other) {
  //   if (other.collider.tag == "Player") isTouchingPlayer = true;
  //   other.
  //   GetComponent<AudioSource>().PlayOneShot(shakeSFX);
  // }
  // private void OnCollisionExit2D(Collision2D other) {
  //   if (other.collider.tag == "Player") isTouchingPlayer = false;
  // }
}
