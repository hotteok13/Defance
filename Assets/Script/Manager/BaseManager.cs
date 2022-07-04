using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public int hp;
    private bool bossCheak;
    public bool teamCheak;

    private void Start()
    {
        bossCheak = true;
    }

    void Update()
    {
        if (hp < 1000 && teamCheak == true && bossCheak == true)
        {
            Instantiate(Resources.Load<GameObject>("EnemyReaper"), new Vector3(0, 0, 50), Quaternion.Euler(0, 180, 0));
            bossCheak = false;
        }
    }
}
