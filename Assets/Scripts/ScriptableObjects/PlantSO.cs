using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName="Flower", fileName = "New Flower")]
public class PlantSO : ScriptableObject
{
    [SerializeField] Vector3 position;
    [SerializeField] DateTime dateTimePlanted;
    
    public Vector3 GetPosition => position;
    public DateTime GetDateTimePlanted() => dateTimePlanted;
    
}
