using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;

public class Stuff
{
    public int money;
    
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public Stuff stuff = new Stuff();

    public Text moneyText;

    private void Start()
    {
        instance = this;
        Load();
    }

    private void Update()
    {
        moneyText.text = stuff.money.ToString();
    }

    public void MoneyIncrease(int value)
    {
        stuff.money += value;
        Save();
    }

    public void Save()
    {
        string jsonData= JsonConvert.SerializeObject(stuff);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
        string format = System.Convert.ToBase64String(bytes);


        File.WriteAllText(Application.dataPath + "Data.json", format);

        
    }
    
    public void Load()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "Data.json");
        byte[] bytes = System.Convert.FromBase64String(jsonData);
        string format = System.Text.Encoding.UTF8.GetString(bytes);

        stuff=JsonConvert.DeserializeObject<Stuff>(format);
        
    }
}
