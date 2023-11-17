using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

// https://www.youtube.com/watch?v=mntS45g8OK4
public class SaveDemo : MonoBehaviour
{
  [field: SerializeField] public MapManager MyMapManager { get; private set; }
  SaveData saveData;
  IDataService dataService = new JsonDataService();
  [SerializeField] TimeSystem timeSystem;
  bool encryptionEnabled = false;
  long saveTime;
  long loadTime;
  string relativePath = "/save-data.json";

  void Awake()
  {
  }

  void CreateNewSaveData()
  {
    if (saveData == null)
    {
      saveData = new SaveData();
      saveData.SetSaveDateTime(timeSystem.Now());
      saveData.PlayerName = "Demo-chan";
      saveData.MapName = "Demo Town";
      saveData.BlockTilemapData = MyMapManager.GetBlockTilemapData();
    }
  }

  public void SerializeJson()
  {
    long startTime = DateTime.Now.Ticks;

    if (saveData == null) CreateNewSaveData();
    else saveData.SetSaveDateTime(timeSystem.Now());
    Debug.Log("save data dt: " + saveData.TimeLastSaved.ToString());

    if (dataService.SaveData(relativePath, saveData, encryptionEnabled))
    {
      saveTime = DateTime.Now.Ticks - startTime;
      Debug.Log($"Save Time: ${saveTime / TimeSpan.TicksPerMillisecond:N4}ms");
      Debug.Log("Saved File:" + JsonConvert.SerializeObject(saveData));
    }
    else
    {
      Debug.LogError("Could not save file! Show something on the UI about it!");
      // InputField.text = "<color=#ff0000>Error saving data!</color>";
    }
  }

  public void LoadSaveData()
  {
    long startTime = DateTime.Now.Ticks;
    try
    {
      saveData = dataService.LoadData<SaveData>(relativePath, encryptionEnabled);
      timeSystem.SetNow(saveData.TimeLastSaved);
      loadTime = DateTime.Now.Ticks - startTime;
      Debug.Log($"Load Time: ${loadTime / TimeSpan.TicksPerMillisecond:N4}ms");
      Debug.Log("Loaded File:" + JsonConvert.SerializeObject(saveData));
      // Debug.Log("Loaded File:\r\n" + JsonConvert.SerializeObject(saveData, Formatting.Indented));
    }
    catch (Exception e)
    {
      Debug.LogError($"Could not read file! Show something on the UI here! {e.Message} {e.StackTrace}");
      // InputField.text = "<color=#ff0000>Error loading save file!<color>";
    }

  }
}
