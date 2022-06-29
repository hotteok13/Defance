using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Infomation : MonoBehaviour
{
    public int price;
    public int money;
    public Text moneyUI;

    public void Start()
    {
        moneyUI.text=money.ToString();
    }
}
