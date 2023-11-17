using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Temperatures { None, Burning, Hot, Warm, Mild, Cool, Cold, Freezing }

public class TemperatureSystem : MonoBehaviour
{
  // Temperature can have three levels of hot and cold.
  // Summer bumps the heat levels up by 1, winter bumps the cold down by 1
  // Sunny days bump the heat up 1, rainy/snowy days bump down by 1
  // Hot areas like beach/desert get 1 heat level
  // Cold areas like tundras/mountains get 1 cold level
  // Cold level 2-3 causes rain to be snow. Cold level 3 freezes ponds/lakes.
  
  // Clothing and food can adjust your player temperature
  // Consequences: Your character is slower in bad temps, uses more energy or 
  // can't take big actions requiring energy, can eventually get sick status if
  // you ignore it long enough to 'collapse'.
  
  // When sick, other NPCs will avoid you, you'll be slow all day, you can take 
  // medicine to cure it by the next day (else it lasts 3 days), you can make
  // others sick if you get too close without protection like a mask
  // Sickness should not be so bad the game is unplayable. There should me many
  // non-energy-dependent tasks to still do to take it easy. Players should be
  // able to deal with NPCs with some prep like masks, gloves, etc..

    // Start is called before the first frame update
    
    [SerializeField] TimeSystem timeSystem;
    [SerializeField] WeatherSystem weatherSystem;
    public int CurrentTempValue { get; private set; }
    
    int AdjustTempForSeason()
    {
      return timeSystem.CurrentSeason switch
      {
        TimeSystem.Season.Spring => 1,
        TimeSystem.Season.Summer => 2,
        TimeSystem.Season.Autumn => -1,
        TimeSystem.Season.Winter => -2,
        _ => 0
      };
    }
    
    int AdjustTempForWeather()
    {
      return weatherSystem.currentWeatherType switch
      {
        WeatherSystem.WeatherTypes.Rain => -1,
        _ => 0
      };
    }

    public Temperatures GetCurrentTemp()
    {
      int newTempValue = 0;
      newTempValue += AdjustTempForSeason();
      newTempValue += AdjustTempForWeather();
      
      if (newTempValue <= -3) return Temperatures.Freezing;
      else if (newTempValue == -2) return Temperatures.Cold;
      else if (newTempValue == -1) return Temperatures.Cool;
      else if (newTempValue == 0) return Temperatures.Mild;
      else if (newTempValue == +1) return Temperatures.Warm;
      else if (newTempValue == +2) return Temperatures.Hot;
      else if (newTempValue >= +3) return Temperatures.Burning;
      else return Temperatures.None;
    }
    
    
    
}
