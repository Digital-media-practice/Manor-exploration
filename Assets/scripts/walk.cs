using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ConsoleApplication2
{
    public class walk : MonoBehaviour
    {
        private AudioSource au;//��Ƶ���
                               // Start is called before the first frame update
        void Start()
        {
            au = GetComponent<AudioSource>();
            au.enabled = false;//��ȡ��Ƶ���
        }

        // Update is called once per frameS
        void Update()
        {
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))//��������˿ո��
            {
                
                
                    au.enabled = true;
                

            }
            else 
                     au.enabled = false;
                     
        }
    }

}