using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private GameObject player;
    private playerSpawn SpawnControl;
    private GameObject Spawn;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        SpawnControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<playerSpawn>();
        
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnPlayer();
    }
   
}
