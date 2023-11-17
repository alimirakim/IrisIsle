using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightScreen : MonoBehaviour
{
  [SerializeField] Color lightColor;
  [SerializeField] int alpha;
  Color lightColorDawn = new Color(1f,1f,0f,0.1f);
  Color lightColorDay = new Color(0,0,0,0);
  Color lightColorDusk = new Color(1f, 0f, 0f, 0.2f);
  Color lightColorNight = new Color(0.05f, 0f, 0.2f, 0.5f);
  SpriteRenderer spriteRenderer;
  
    // 4am to 7am = night to dawn (yellowish
    // 7 to 9am = to day (no filter)
    // 4pm to 6pm = day to dusk (burnt orange)
    // 6 to 8pm = dusk to night
  
    // Start is called before the first frame update
    void Start()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();
      
      InvokeRepeating("UpdateLightBasedOnTimeOfDayMVP", 0, 60);
      
      // TODO Create smooth, gradual transitions between light effects
      // InvokeRepeating("UpdateLightBasedOnTimeOfDay", 0, 60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void UpdateLightBasedOnTimeOfDayMVP()
    {
      
      // Get the current time
      TimeSpan now = DateTime.Now.TimeOfDay;
      
      // MVP of light changes based on time of day
      if (now.Hours > 4 && now.Hours <= 9)
        spriteRenderer.color = lightColorDawn;
      else if (now.Hours > 9 && now.Hours <= 16)
        spriteRenderer.color = lightColorDay;
      else if (now.Hours > 16 && now.Hours <= 20)
        spriteRenderer.color = lightColorDusk;
      else
        spriteRenderer.color = lightColorNight;
    }
    
    // TODO GOOGLE LERPING: https://stackoverflow.com/questions/47612094/lerping-between-two-colors
    void UpdateLightBasedOnTimeOfDay()
    {
      TimeSpan now = DateTime.Now.TimeOfDay;
      
      // Color transitions are to/from dawn and to/from dusk
      TimeSpan startOfDawn = new TimeSpan(4, 0, 0);
      TimeSpan dawn = new TimeSpan(7, 0, 0);
      TimeSpan day = new TimeSpan(9, 0, 0);
      TimeSpan startOfDusk = new TimeSpan(16, 0, 0);
      TimeSpan dusk = new TimeSpan(18, 0, 0);
      TimeSpan night = new TimeSpan(20, 0, 0);
      
      // adjust light color and intensity from night to dawn
      if (now.Hours > 4 && now.Hours <= 9) {
        
        int timeDifferenceMinutes = new TimeSpan(7 - 4, 0, 0).Minutes;
        
        lightColor = lightColorDawn;
        // alpha = 
      }
    }


}
