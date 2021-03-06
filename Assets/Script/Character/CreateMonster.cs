using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMonster : MonoBehaviour
{
    public Button goblineButton;
    public Button hapineButton;
    public Button dragonButton;
    public Button reaperButton;


    public void Start()
    {
        InvokeRepeating("EnemyInstance", 0, 5);
    }

    public void Create(string name)
    {
       
        switch (name)
        {
            
            case "Gobline":
                if (DataManager.instance.stuff.money >= 1000)
                {
                    Instantiate(Resources.Load<GameObject>("Goblin_B"), new Vector3(0, 0, 13), Quaternion.Euler(0, 0, 0));

                    StartCoroutine(Wait(3.0f, goblineButton));
                    DataManager.instance.stuff.money -= 1000;
                }
                break;
            case "Hapine":
                if (DataManager.instance.stuff.money >= 2000)
                {
                    Instantiate(Resources.Load<GameObject>("Hapine"), new Vector3(0, 2, 10), Quaternion.Euler(0, 0, 0));

                    StartCoroutine(Wait(5.0f, hapineButton));
                    DataManager.instance.stuff.money -= 2000;
                }
                break;
            case "Dragon":
                if (DataManager.instance.stuff.money >= 15000)
                {
                    Instantiate(Resources.Load<GameObject>("Dragon"), new Vector3(0, 0, 13), Quaternion.Euler(0, 0, 0));

                    StartCoroutine(Wait(25.0f, dragonButton));
                    DataManager.instance.stuff.money -= 15000;
                }
                
                break;
            case "Reaper":
                if (DataManager.instance.stuff.money >= 5000)
                {
                    Instantiate(Resources.Load<GameObject>("Reaper"), new Vector3(0, 0, 10), Quaternion.Euler(0, 0, 0));
                    StartCoroutine(Wait(15.0f, reaperButton));
                    DataManager.instance.stuff.money -= 5000;
                }
                
                break;

        }
    }



    public void EnemyInstance()
    {
        if (!GameManager.instace.state) return;
        int rand = Random.Range(0, 3);
        if (rand == 1)
        {
            Instantiate(Resources.Load<GameObject>("Goblin_R"), new Vector3(0, 0, 50), Quaternion.Euler(0, -180, 0));
        }

    }

    IEnumerator Wait(float timer, Button button)
    {

        button.interactable = false;

        while (timer > 1.0f)
        {
            timer -= Time.deltaTime;
            button.image.fillAmount = (1.0f / timer);
            yield return new WaitForFixedUpdate();
        }
        //yield return new WaitForSeconds(timer);
        button.interactable = true;


    }

}
