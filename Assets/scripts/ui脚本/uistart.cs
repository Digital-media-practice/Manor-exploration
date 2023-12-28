using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uistart : MonoBehaviour
{
    GameObject[] uis;
    // Start is called before the first frame update
    private void Awake()
    {
        uis = GameObject.FindGameObjectsWithTag("ui");
    }
    void Start()
    {
        for (int i = 0; i < uis.Length; i++)
        {

            if (uis[i].name != "开始界面")
            {
                uis[i].SetActive(false);
            }
        }
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
