using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
  [SerializeField] Sprite[] growthSprites;
  [SerializeField] PlantSO plantData;
  SpriteRenderer spriteRenderer;
  [SerializeField] int daysPerStage; 
  
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = growthSprites[GetGrowthIndex()];
        
        
    }
    
    public bool GetIsFullyGrown() => GetGrowthIndex() == growthSprites.Length - 1 ? true : false;
    
    // TODO Test logic and edge cases.
    int GetGrowthIndex()
    {
      TimeSpan timeSincePlanted = DateTime.Now - plantData.GetDateTimePlanted();
      // TODO Fix broken logic
      int growthState = timeSincePlanted.Seconds / daysPerStage;
      // int growthState = timeSincePlanted.Days / growthInterval;
      
      return growthState >= growthSprites.Length ? growthSprites.Length - 1 : growthState;
    }
    
    IEnumerator MaintainSpriteGrowth() 
    {
      while (true) 
      {
        spriteRenderer.sprite = growthSprites[GetGrowthIndex()];
        if (GetIsFullyGrown()) {
          yield break;
        }
        
        yield return new WaitForSeconds(1f);
      }
    }
}
