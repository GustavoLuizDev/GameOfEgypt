using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    public GameObject DefeatScreen;
    public GameObject VictoryScreen;
    float time;
     public List<GameObject> Itens;
    public List<Transform> SpawnPoints;
    public List<Transform> TargetMission;
    public GameObject particleSystemMission;
    public GameObject actualObject;
    public Transform actualMission;
    public Transform boneHand;
    bool objectInHand;
    public int points;
    public int life;
     public TextMeshProUGUI textMeshProComponent;
     public TextMeshProUGUI textMeshProLife;
    void Update()
    {
        textMeshProLife.text = "Life: "+life.ToString();
        textMeshProComponent.text = "Pontuation: "+points.ToString();
        if (actualObject==null)
        {
            var c = Random.Range(0, SpawnPoints.Count);
            var d = Random.Range(0, Itens.Count);
            actualObject = Instantiate(Itens[d], SpawnPoints[c].position, SpawnPoints[c].rotation);
        }

        if (actualObject!=null && objectInHand==false && Vector3.Distance(transform.position, actualObject.transform.position)<1)
        {
            actualObject.transform.position=boneHand.position;
            actualObject.transform.localScale =new Vector3(0.0003f,0.0003f,0.0003f);
            actualObject.transform.parent = boneHand;
            objectInHand=true;
        }
        else if(actualObject!=null && objectInHand==true )
        {
            if (actualMission==null)
            {
                actualMission = TargetMission[Random.Range(0,TargetMission.Count)];
                var z = Instantiate(particleSystemMission, actualMission.position, actualMission.rotation);
                z.transform.parent=actualMission;
            }
            else if(Vector3.Distance(transform.position, actualMission.position)<1)
            {
                points +=10;
                Destroy(actualObject);
                var particle =actualMission.GetChild(0);
                Destroy(particle.gameObject);
                actualMission=null;
                objectInHand=false;
            }
        }
        if (points>=50)
        {
            VictoryScreen.SetActive(true);
        }
        else if(life<=0)
        {
            DefeatScreen.SetActive(true);
        }
        
        
    }
}
