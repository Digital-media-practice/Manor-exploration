using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void OnExitGame()
    {
#if UNITY_EDITOR//1�ڱ༭��ģʽ���˳�
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
