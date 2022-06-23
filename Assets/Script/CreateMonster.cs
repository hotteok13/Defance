using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public void GoblinCreate()
    {
        Instantiate(Resources.Load<GameObject>("Goblin_B"),new Vector3(0,0,13),Quaternion.Euler(0,0,0));
    }
    public void HapineCreate()
    {
        Instantiate(Resources.Load<GameObject>("Hapine"), new Vector3(0, 2, 13), Quaternion.Euler(-60, 0, 0));
    }
}
