using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName="Create Tree", fileName = "New Tree Data")]
public class TreeSO : ScriptableObject
{
  
    [SerializeField] Vector3 position;
    [SerializeField] int dateTimePlantedTicks;
    [SerializeField] bool isChopped;
    [SerializeField] TreeTypes treeType = TreeTypes.None;
    
    public Vector3 GetPosition() => position;
    public DateTime GetDateTimePlanted() => new DateTime(dateTimePlantedTicks);
    public bool GetIsChopped() => isChopped;
    public TreeTypes GetTreeType() => treeType;
}



// LIST of trees on map
// tree has:
// xy grid location
// growth state (sapling, young tree, tree, fruit1, fruit2, fruit3, fruit4, fruit5, cut)
// age
// time ticker for fruit growth
// tree type - pine, normal, fruit
// each individual fruit can be a golden/perfect fruit

// on game startup...
// game checks TreesList, which loops through each TreeSO, 
// which populates the tree in its current state and location on the map
// with invokeRepeating, every tree will grow more fruit on a delay schedule in realtime
// with player interaction, trees are shaken and lose their fruit
