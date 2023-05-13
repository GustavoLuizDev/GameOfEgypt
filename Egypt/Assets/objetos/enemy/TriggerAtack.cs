using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAtack : MonoBehaviour
{
    public Transform objectTrigged;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objectTrigged=other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && other.transform == objectTrigged)
        {
            objectTrigged=null;
        }
    }
}
