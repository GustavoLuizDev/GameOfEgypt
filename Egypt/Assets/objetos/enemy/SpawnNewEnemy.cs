using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewEnemy : MonoBehaviour
{
    public Transform playerRef;
    public GameObject EnemyBody;
    public float timeSpawn;
    float timeGeneral;

    // Update is called once per frame
    void Update()
    {
        timeGeneral +=Time.deltaTime;

        if (timeGeneral>timeSpawn)
        {
            var a = Random.Range(0,4);
            var b = Random.Range(0,4);
            var c= new Vector3(transform.position.x+a,transform.position.y,transform.position.z+b);
            var z=Instantiate(EnemyBody, c, transform.rotation);
            z.transform.GetComponent<Follow>().player=playerRef;
            timeGeneral=0;
        }
    }
}
