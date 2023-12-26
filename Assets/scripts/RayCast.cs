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
        //�������߼��,�õ����ǰ뾶2�׷�Χ�����е����
        Collider[] cols = Physics.OverlapSphere(playerTransform.position, radius);
        //Debug.Log("�������нű�");
        //�жϼ�⵽���������û��Enemy
        if (cols.Length > 0)
            for (int i = 0; i < cols.Length; i++)
                //�ж��Ƿ��ǹ���
                if (cols[i].tag.Equals("�ɽ���"))
                {
                    //�жϵ����Ƿ�������ǰ��60�ȷ�Χ��
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
