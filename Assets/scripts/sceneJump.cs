using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneJump : MonoBehaviour
{
    public Scene scene;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Jump()//第一个场景 
    {
        SceneManager.LoadScene(scene.name);
    }

}