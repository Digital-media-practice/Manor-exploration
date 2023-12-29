using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    public GameObject[] Spawns;
    
    // Start is called before the first frame update
    private void Awake()
    {
        Spawns = GameObject.FindGameObjectsWithTag("³öÉúµã");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject getSpawn(int id)
    {
        GameObject Spawn=Spawns[id];
        return Spawn; 
    }
}
