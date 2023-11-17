using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBag : MonoBehaviour
{
    [SerializeField] List<PickupItem> items;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    List<PickupItem> GetItems() => items;
    
    void AddItem(PickupItem addedItem, int quantity)
    {
      
    }
    
    void RemoveItem(PickupItem removedItem)
    {
      
    }
    
    void SortItems()
    {
      
    }
    
}
