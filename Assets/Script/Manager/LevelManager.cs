using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public string level;
    
    public void GetLevel(string name)
    {
        switch (level)
        {
            case "Level 1":
                transform.GetComponent<MonsterControl>().health *= 1;
                transform.GetComponent<MonsterControl>().attack *= 1;
                break;
            case "Level 2":
                transform.GetComponent<MonsterControl>().health *= 2;
                transform.GetComponent<MonsterControl>().attack *= 2;
                break;
            case "Level 3":
                transform.GetComponent<MonsterControl>().health *= 3;
                transform.GetComponent<MonsterControl>().attack *= 3;

                break;
        }
    }
}
