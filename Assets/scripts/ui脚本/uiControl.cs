using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class uiControl : MonoBehaviour
{
    GameObject[] uis;
    GameObject fater;
    bool mouse;
    public Scene scene;
    // Start is called before the first frame update
    private void Awake()
    {
        uis = GameObject.FindGameObjectsWithTag("ui");
    }
    void Start()
    {
        if(transform.parent!=null)
        fater=transform.parent.gameObject;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameStart()
    {
        
        for (int i = 0; i < uis.Length; i++)
        {

            if (uis[i].name == "运行界面")
            {
                uis[i].gameObject.SetActive(true);
                fater.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                break;
            }
        }
    }
    public void gameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void gameSet()
    {
        for (int i=0;i<uis.Length;i++)
        {
            
            if (uis[i].name=="设置界面")
            {
                uis[i].gameObject.SetActive(true);
                fater.SetActive(false);
                Time.timeScale = 0;
                break;
            }
        }
    }
    public void changeScene1()
    {
        SceneManager.LoadScene(0);
    }
    public void changeScene2()
    {
        SceneManager.LoadScene(1);
    }
    public void changeScene3()
    {
        SceneManager.LoadScene(2);
    }
    public void changeScene4()
    {
        SceneManager.LoadScene(3);
    }

    public void mouseShow(InputAction.CallbackContext ctx)
    {
        mouse = ctx.ReadValueAsButton();
        if (mouse)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
