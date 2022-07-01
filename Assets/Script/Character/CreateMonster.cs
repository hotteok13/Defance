using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMonster : MonoBehaviour
{
    public Button goblineButton;
    public Button hapineButton;
    public Button dragonButton;

    private bool goblineCheak=true;
    private bool hapineCheak=true;
    private bool dragonCheak=true;
    
    public void Start()
    {
        InvokeRepeating("EnemyInstance", 0, 5);
    }
    public void GoblinCreate()
    {
        
        Instantiate(Resources.Load<GameObject>("Goblin_B"),new Vector3(0,0,13),Quaternion.Euler(0,0,0));
        goblineCheak = false;
        StartCoroutine(Wait(3.0f));
    }
    public void HapineCreate()
    {
        Instantiate(Resources.Load<GameObject>("Hapine"), new Vector3(0, 2, 10), Quaternion.Euler(0, 0, 0));
        hapineCheak = false;
        StartCoroutine(Wait(5.0f));
    }
    public void DragonCreate()
    {

        Instantiate(Resources.Load<GameObject>("Dragon"), new Vector3(0, 0, 13), Quaternion.Euler(0, 0, 0));
        dragonCheak = false;
        StartCoroutine(Wait(3.0f));
    }
    public void EnemyInstance()
    {
        if (!GameManager.instace.state) return;
        int rand = Random.Range(0, 3);
        if (rand == 1)
        {
            Instantiate(Resources.Load<GameObject>("Goblin_R"), new Vector3(0, 0, 40), Quaternion.Euler(0, -180, 0));
        }
        
    }

    IEnumerator Wait(float timer)
    {
        if (goblineCheak == false)
        {
            goblineButton.interactable = false;
            
            while (timer > 1.0f)
            {
                timer -= Time.deltaTime;
                goblineButton.image.fillAmount = (1.0f / timer);
                yield return new WaitForFixedUpdate();
            }
            //yield return new WaitForSeconds(timer);
            goblineButton.interactable = true;
            goblineCheak = true;
        }
        else if(hapineCheak == false)
        {
            hapineButton.interactable = false;
            
            while (timer > 1.0f)
            {
                timer -= Time.deltaTime;
                hapineButton.image.fillAmount = (1.0f / timer);
                yield return new WaitForFixedUpdate();
            }
            //yield return new WaitForSeconds(timer);
            hapineButton.interactable = true;
            hapineCheak = true;
        }
        else if (dragonCheak == false)
        {
            dragonButton.interactable = false;

            while (timer > 1.0f)
            {
                timer -= Time.deltaTime;
                dragonButton.image.fillAmount = (1.0f / timer);
                yield return new WaitForFixedUpdate();
            }
            //yield return new WaitForSeconds(timer);
            dragonButton.interactable = true;
            dragonCheak = true;
        }
    }
}
