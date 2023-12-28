using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosethePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
