using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManage : MonoBehaviour
{
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("Panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePanel()
    {
        if(panel.activeSelf == true)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
}
