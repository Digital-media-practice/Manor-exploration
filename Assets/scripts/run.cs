using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    private AudioSource au1;//��Ƶ���
    // Start is called before the first frame update
    void Start()
    {
        au1 = GetComponent<AudioSource>();//��ȡ��Ƶ���
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left shift"))
        {

            au1.enabled = true;

        }
        else
            au1.enabled = false; 
        
    }
}

