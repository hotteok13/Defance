using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public void Start()
    {
        InvokeRepeating("EnemyInstance", 0, 5);
    }
    public void GoblinCreate()
    {
        Instantiate(Resources.Load<GameObject>("Goblin_B"),new Vector3(0,0,13),Quaternion.Euler(0,0,0));
    }
    public void HapineCreate()
    {
        Instantiate(Resources.Load<GameObject>("Hapine"), new Vector3(0, 2, 13), Quaternion.Euler(-60, 0, 0));
    }

    public void EnemyInstance()
    {
        int rand = Random.Range(0, 3);
        if (rand == 1)
        {
            Instantiate(Resources.Load<GameObject>("Goblin_R"), new Vector3(0, 0, 40), Quaternion.Euler(0, -180, 0));
        }
        
    }
}
