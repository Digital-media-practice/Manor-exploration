using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    Transform playerTransform;
    int radius=5;
    int angles=40;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform= transform;
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
        //球形射线检测,得到主角半径2米范围内所有的物件
        Collider[] cols = Physics.OverlapSphere(playerTransform.position, radius);
        //Debug.Log("正在运行脚本");
        //判断检测到的物件中有没有Enemy
        if (cols.Length > 0)
            for (int i = 0; i < cols.Length; i++)
                //判断是否是怪物
                if (cols[i].tag.Equals("可交互"))
                {
                    //判断敌人是否在主角前方60度范围内
                    Vector3 dir = cols[i].transform.position - playerTransform.position;
                    if (Vector3.Angle(dir, playerTransform.forward) < angles)
                    {
                        if (cols[i].GetComponent<Outline>().enabled == false)
                            cols[i].GetComponent<Outline>().enabled = true;
                    }
                    else
                    {
                        if (cols[i].GetComponent<Outline>().enabled == true)
                            cols[i].GetComponent<Outline>().enabled = false;
                    }
                }
    }
}
