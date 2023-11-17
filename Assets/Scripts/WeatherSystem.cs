using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
  // IDEA Break weather cycles into two types: 1st is daily weather cycle where
  // the day is categorized as 'Clear', 'Cloudy', 'Rainy', 'Stormy'.
  // This is basically the 'weatherman forecast' that predicts the general
  // projection of the day's weather.
  // Each weather-day-type has its own drawing pool of chances for weather.
  // Then on the day, every 3 hours rolls a new weather type based on the chance
  // table for that weather-day-type.
  // Ex. it's a 'Rainy' day, so every 3 hours there's a:
  //   10% chance of clear sky, 30% of clouds, 40% of rain, 20% of storms
  // + if clouds come before rain, they become rainclouds
  // + if rain starts without clouds before, it has a 10min cloud prelude
  
  
    public enum WeatherTypes { None, Clear, Cloudy, Rain }
    // enum WeatherTypes { None, Clear, Sunny, Cloudy, LightRain, Rain, HeavyRain, Storm }
    
    [SerializeField] SeasonSystem seasonSystem;
    [SerializeField] TimeSystem timeSystem;
    [SerializeField] TemperatureSystem tempSystem;
    [SerializeField] Material raindropParticle;
    [SerializeField] Material snowdropParticle;
    [SerializeField] Material cloudShadowParticle;
    int emissionRateOverTime;
    
    public WeatherTypes currentWeatherType;
    [SerializeField] ParticleSystem weatherParticleSystem;
    ParticleSystemRenderer particleSystemRenderer;
    ParticleSystem.EmissionModule particleSystemEmission;
    ParticleSystem.MainModule particleSystemMain;
    
  
    // Start is called before the first frame update
    void Start()
    {
      particleSystemRenderer = weatherParticleSystem.GetComponent<ParticleSystemRenderer>();
      particleSystemEmission = weatherParticleSystem.emission;
      particleSystemMain = weatherParticleSystem.main;
      
      InvokeRepeating("UpdateWeather", 0, 6);
      
      // Update weather every 3 hours
      // InvokeRepeating("UpdateWeather", 0, 10800);
    }
    
    public string GetWeatherLabel() => currentWeatherType.ToString();
    
    void UpdateWeather()
    {
      currentWeatherType = GenerateWeather();

      // TODO Create transitions between particle effects
      switch (currentWeatherType)
      {
        case WeatherTypes.Clear:
          particleSystemEmission.rateOverTime = 0;
          break;
        case WeatherTypes.Cloudy:
          // TODO Add light gray filter, cloud shadow particles
            ChangeToSnowParticleEffects();
          break;
        case WeatherTypes.Rain:
          if (seasonSystem.currentSeason == SeasonSystem.Seasons.Winter) 
            ChangeToSnowParticleEffects();
          else
          // TODO Add blue filter, rain particles
            ChangeToRainParticleEffects();
          break;
        default:
          break; // TODO Throw error in this case
      }
    }
    
    void ChangeToSnowParticleEffects()
    {
        // or for a funky light heavy effect:
        // yourParticleEmission.rateOverTime = Mathf.Lerp(particleEmissionMin, particleEmissionMax, startOfEmission/ emissionLength);
        // particleSystemEmission.rateOverTime = Mathf.Lerp(1f, 50f, 1 / 10);
        particleSystemRenderer.material = snowdropParticle;
        particleSystemEmission.rateOverTime = 50;
        particleSystemMain.startLifetime = new ParticleSystem.MinMaxCurve(2, 8);
        particleSystemMain.startSpeed = new ParticleSystem.MinMaxCurve(4, 8);
    }
    
    void ChangeToRainParticleEffects()
    {
        particleSystemRenderer.material = raindropParticle;
        particleSystemEmission.rateOverTime = 50;
        particleSystemMain.startLifetime = new ParticleSystem.MinMaxCurve(0.5f, 1);
        particleSystemMain.startSpeed = new ParticleSystem.MinMaxCurve(20, 40);
    }
    
    // TODO Wind system, mist/fog, sunshowers, meteor showers
    // TODO Have stormclouds before rain and storms
    // MAYBE Generate weather forecast for a week ahead. Every day during TV
    // forecast time or game bootup, generate any missing info. 
    // Roll to decide the next weather type, then roll to decide its timelength.
    // Inclement weather gets a 30-120 minute stormcloud prelude 
    // depending on its timelength (ex. 8 hour rain gets 90-min clouds), 
    // unless the previous weather is also inclement (ex. rain, then heavyrain).
    // Weather can last between 1-12 hours.
    WeatherTypes GenerateWeather() {
      Dictionary<WeatherTypes, float> weatherChances = new Dictionary<WeatherTypes, float> {
        { WeatherTypes.Clear, 0.5f },
        { WeatherTypes.Cloudy, 0.25f },
        { WeatherTypes.Rain, 0.15f },
        // { WeatherTypes.HeavyRain, 0.05f },
        // { WeatherTypes.Storm, 0.05f },
      };
      
      (WeatherTypes, float)[] weatherTypes = 
      {
        ( WeatherTypes.Clear, 0.35f ),
        ( WeatherTypes.Cloudy, 0.25f ),
        ( WeatherTypes.Rain, 0.40f ),
        // ( WeatherTypes.Rain, 0.10f ),
        // ( WeatherTypes.HeavyRain, 0.05f ),
        // ( WeatherTypes.Storm, 0.05f ),
      };
      
      float weatherValue = UnityEngine.Random.Range(0, 1f);
      
      float accWeatherTypeVal = 0f;
      foreach ((WeatherTypes, float) weatherType in weatherTypes) 
      {
        accWeatherTypeVal += weatherType.Item2;
        if (weatherValue <= accWeatherTypeVal) return weatherType.Item1;
      }
      
      return WeatherTypes.None;
    }
}
