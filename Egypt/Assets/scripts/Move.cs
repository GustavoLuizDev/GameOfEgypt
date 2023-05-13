using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform camera;
    public Animator anim;
    public float velocity;
    Vector3 Target;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Cria um raio a partir da posição do mouse na tela
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verifica se o raio atingiu um objeto com a tag "ground"
            if (Physics.Raycast(ray, out hit) )
            {
                
                if (hit.transform.tag=="Ground")
                {
                    // Obtém a posição hitada no objeto
                    Target = hit.point;

                }
                
            }
        }
    
        if (Target!=Vector3.zero && Vector3.Distance(transform.position, Target)>1f)
        {
            Vector3 targetDirection = Target - transform.position;
            targetDirection.y = 0f; 
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 8 * Time.deltaTime);


            transform.position = Vector3.MoveTowards(transform.position, Target, velocity*Time.deltaTime);

            anim.SetBool("canRun", true);
        }
        else if(Target!=Vector3.zero )
        {
            anim.SetBool("canRun", false);
            Target=Vector3.zero;
        }

        var ze= new Vector3(transform.position.x,transform.position.y,transform.position.z);
        camera.position = Vector3.MoveTowards(camera.position, ze, (velocity*0.85f)*Time.deltaTime);
        
    }
}
