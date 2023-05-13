using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position)>0.8f)
        {
            Vector3 targetDirection = player.position - transform.position;
            targetDirection.y = 0f; 
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 8 * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, player.position, 2.3f*Time.deltaTime);
            anim.SetBool("Atack",false);
        }
        else
        {
            anim.SetBool("Atack",true);
        }
    }
}
