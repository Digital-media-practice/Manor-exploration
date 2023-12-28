using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

   public  int radius=6;

    Outline outline;
    GameObject player;
    Transform[] Objs;
  
    // Start is called before the first frame update
    
    void Start()
    {
       
        outline=GetComponent<Outline>();
        player = GameObject.FindWithTag("Player");

        Objs = GetComponentsInChildren<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
         CheckSurroundings();
    }

    public void CheckSurroundings()
    { 
       float dis=(transform.position - player.transform.position).magnitude;
        if (dis < radius)
        {
            outline.enabled = true;
           
            foreach (Transform t in Objs)
            {
                if (t.gameObject.tag == "ui"&&t.gameObject.activeSelf==false)
                {
                    t.gameObject.SetActive(true);
                }
            }
        }
        else
        { 
            outline.enabled = false;
            foreach (Transform t in Objs)
            {
                if (t.gameObject.tag == "ui")
                {
                    t.gameObject.SetActive(false);
                }
            }
        } 

            
               
        

    }
}
