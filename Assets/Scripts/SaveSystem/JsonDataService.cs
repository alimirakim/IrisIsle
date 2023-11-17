using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataService : IDataService
{
  private const string KEY = "secretkeyman";
  private const string IV = "initialization_vector";

  public bool SaveData<T>(string relativePath, T data, bool encrypted)
  {
    string path = Application.persistentDataPath + relativePath;

    try
    {
      if (File.Exists(path))
      {
        Debug.Log("Data exists. Deleting old file and writing a new one!");
        File.Delete(path);
      }
      else
      {
        Debug.Log("Writing file for the first time~!");
      }
      using FileStream stream = File.Create(path);
      if (encrypted)
      {
        WriteEncryptedData(data, stream);
      }

      stream.Close();
      File.WriteAllText(path, JsonConvert.SerializeObject(data));
      return true;
    }
    catch (Exception e)
    {
      Debug.LogError($"Unable to save data due to: {e.Message} {e.StackTrace}");
      return false;
    }
  }

  private void WriteEncryptedData<T>(T data, FileStream stream)
  {
    // creates Aes algorithm instance
    using Aes aesProvider = Aes.Create();
    aesProvider.Key = Convert.FromBase64String(KEY);
    aesProvider.IV = Convert.FromBase64String(IV);
    using ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor();
    using CryptoStream cryptoStream = new CryptoStream(
      stream, cryptoTransform, CryptoStreamMode.Write
    );

    // You can uncomment the below to see a generated value for IV and Key.
    // You can also generate your own if you wish.
    // Debug.Log($"Initialization Vector: {Convert.ToBase64String(aesProvider.IV)}");
    // Debug.Log($"Key: {Convert.ToBase64String(aesProvider.Key)}");

    cryptoStream.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(data)));

  }

  public T LoadData<T>(string relativePath, bool encrypted)
  {
    string path = Application.persistentDataPath + relativePath;

    if (!File.Exists(path))
    {
      Debug.LogError($"Can't load file at {path}. File doesn't exist.");
      throw new FileNotFoundException($"{path} doesn't exists!");
    }

    try
    {
      T data;
      if (encrypted)
      {
        data = ReadEncryptedData<T>(path);
      }
      else
      {
        data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
      }

      return data;
    }
    catch (Exception e)
    {
      Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
      throw e;
    }
  }

  private T ReadEncryptedData<T>(string path)
  {
    byte[] fileBytes = File.ReadAllBytes(path);
    using Aes aesProvider = Aes.Create();

    aesProvider.Key = Convert.FromBase64String(KEY);
    aesProvider.IV = Convert.FromBase64String(IV);

    using ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor(
      aesProvider.Key,
      aesProvider.IV
    );
    using MemoryStream decryptionStream = new MemoryStream(fileBytes);
    using CryptoStream cryptoStream = new CryptoStream(
      decryptionStream,
      cryptoTransform,
      CryptoStreamMode.Read
    );
    using StreamReader reader = new StreamReader(cryptoStream);

    string result = reader.ReadToEnd();

    Debug.Log($"Decrypted result (if the following is not legible, probably wrong key or iv): {result}");
    return JsonConvert.DeserializeObject<T>(result);
  }

}
