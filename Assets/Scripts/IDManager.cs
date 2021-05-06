using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public static class IDManager
{
    public static IDData currentData = null;

    public static string CreateID(string prefix, int numDigits)
    {
        LoadData();

        if(currentData==null)
        {
            Debug.Log("is null");
        }
        else
        {
            Debug.Log("no es null");
        }


        string newID = "";
        do
        {
            string key = GenerateKey(numDigits);

            newID = prefix + "_" + key;
        } while (!IsAvaliable(newID));

        //Debug.Log(newID);

        RegisterID(newID);

        //SaveData();

        Debug.Log("CereateID");

        return newID;
    }

    private static void LoadData()
    {
        if (currentData == null)
        {
            currentData = (IDData.saveKey + ".json").LoadData<IDData>();
            if(currentData==null)
            {
                currentData = new IDData();
            }
        }
    }

    private static void SaveData()
    {
        currentData.SaveData(IDData.saveKey + ".json");
    }

    private static string GenerateKey(int numDigits)
    {
        string key = "";
        for (int i = 0; i < numDigits; i++)
        {
            key += currentData.possibleDigits.GetRandomChar();
        }
        return key;
    }

    private static char GetRandomChar(this string s)
    {
        int n = UnityEngine.Random.Range(0, s.Length);
        return s[n];
    }

    private static void RegisterID(string id)
    {
        string[] substrings = id.Split('_');

        string key = substrings[substrings.Length - 1];

        substrings[substrings.Length - 1] = "";

        string prefix = String.Join("_", substrings);

        if (currentData.registeredIDs.ContainsKey(prefix))
        {
            currentData.registeredIDs[prefix].Add(key);
        }
        else
        {
            RegisterPrefix(prefix);
            currentData.registeredIDs[prefix].Add(key);
        }

        
    }

    private static bool IsAvaliable(string id)
    {
        string[] substrings = id.Split('_');

        string key = substrings[substrings.Length - 1];

        substrings[substrings.Length - 1] = "";

        string prefix = String.Join("_", substrings);

        if(currentData.registeredIDs.ContainsKey(prefix))
        {
            if(!currentData.registeredIDs[prefix].Contains(key))
            {
                return true;
            }
        }
        else
        {
            return true;
        }
        return false;
    }

    private static void RegisterPrefix(string prefix)
    {
        currentData.registeredIDs.Add(prefix, new List<string>());
    }
}

[System.Serializable]
public class IDData
{


    public static string saveKey = "IDData";

    public string possibleDigits = "0123456789ABCDEF";

    public SerializableDictionary<string, List<string>> registeredIDs = new SerializableDictionary<string, List<string>>();

    public IDData()
    {
        registeredIDs = new SerializableDictionary<string, List<string>>();
        possibleDigits = "0123456789ABCDEF";
        saveKey = "IDData";
    }

}

