using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPurse : MonoBehaviour
{
  [SerializeField] int coins;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public int GetCoins() => coins;
    
    public int AddCoins(int addedCoins) => coins += addedCoins;
    
    public int LoseCoins(int lostCoins) => coins -= lostCoins;
    
}
