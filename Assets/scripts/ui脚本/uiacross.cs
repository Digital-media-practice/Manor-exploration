using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiacross : MonoBehaviour
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

            if (uis[i].name != "运行界面")
            {
                uis[i].SetActive(false);
            }
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
