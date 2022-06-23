using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfomation : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
            Destroy(gameObject,5);
        }
    }
    private void OnDestroy()
    {
        
    }
}
