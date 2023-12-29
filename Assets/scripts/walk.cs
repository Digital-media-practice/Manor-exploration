using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ConsoleApplication2
{
    public class walk : MonoBehaviour
    {
        private AudioSource au;//音频组件
                               // Start is called before the first frame update
        void Start()
        {
            au = GetComponent<AudioSource>();
            au.enabled = false;//获取音频组件
        }

        // Update is called once per frameS
        void Update()
        {
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))//如果按下了空格键
            {
                
                
                    au.enabled = true;
                

            }
            else 
                     au.enabled = false;
                     
        }
    }

}