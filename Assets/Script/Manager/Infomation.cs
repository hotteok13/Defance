using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Data
{
    public int price;

    public Sprite shape;
    public Sprite priceSprite;
}


public class Infomation : MonoBehaviour
{
    public Data [] data;
    public Image [] monsterUI;
    public Image [] priceUI;

    private void Start()
    {
        for(int i = 0; i < data.Length; i++)
        {
            monsterUI[i].sprite = data[i].shape;
            priceUI[i].sprite = data[i].priceSprite;

        }
        
    }
}
