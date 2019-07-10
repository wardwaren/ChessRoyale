using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCheck : MonoBehaviour
{
    [SerializeField] EnemyControl control;

    Text WaveText;
    
    // Start is called before the first frame update
    void Start()
    {
        WaveText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(control.getStarted() == false)
        {
            WaveText.text = "Wave " + (control.getWave()+1).ToString()
            + " in " + control.getTime().ToString();
        }
        else
        {
            WaveText.text = "";
        }
        
    }
}
