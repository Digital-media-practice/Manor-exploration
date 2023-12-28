using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getkeys : MonoBehaviour
{
    GameObject player;
    GameObject[] uis;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uis = GameObject.FindGameObjectsWithTag("ui");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void addkey()
    {
        player.gameObject.GetComponent<PlayerController>().getKey();
        Transform[] myTransforms = GetComponentsInChildren<Transform>();
        foreach (var child in myTransforms)
        {
           child.gameObject.SetActive(false);
          // Destroy(child.gameObject);
        }
    }
    public void checkKeys()
    {
        if (player.gameObject.GetComponent<PlayerController>().keys == 3)
        {
            
            for (int i = 0; i < uis.Length; i++)
            {

                if (uis[i].name == "结束界面")
                {
                    uis[i].gameObject.SetActive(true);
            
                    Time.timeScale = 0;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < uis.Length; i++)
            {

                if (uis[i].name == "钥匙不够")
                {
                    uis[i].gameObject.SetActive(true);

                    Time.timeScale = 0;
                    break;
                }
            }
        }
    }
}
