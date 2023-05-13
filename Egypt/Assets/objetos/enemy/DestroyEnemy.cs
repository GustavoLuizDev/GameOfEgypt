using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public Transform hand;
    public void destroythis()
    {
        //Destroy(transform.parent.transform.gameObject);
    }
    public void DetectGolpe()
    {
        if (hand.GetComponent<TriggerAtack>().objectTrigged !=null)
        {
            hand.GetComponent<TriggerAtack>().objectTrigged.GetComponent<SpawnRandom>().life -= 50;
        }
        
    }
}
