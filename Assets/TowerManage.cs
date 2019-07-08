using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManage : MonoBehaviour
{
    [SerializeField] int valmin = 1;
    [SerializeField] int valmax = 5;

    GameObject panel;
    EnemyControl EnemyControl;

    int wave = -1;
    // Start is called before the first frame update
    void Start()
    {
        EnemyControl = FindObjectOfType<EnemyControl>();
        panel = GameObject.Find("Panel");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Debug.Log("Wave: " + wave);
      //  Debug.Log("GetWave: " + EnemyControl.getWave());

        if (wave == EnemyControl.getWave())
        {

            foreach(Transform child in panel.transform)
            {
                Button button = child.gameObject.GetComponent<Button>();

                button.GetComponentInChildren<Text>().text = Random.Range(valmin, valmax).ToString();
                
            }
            wave++;
        }
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
    
    public void AssignValue()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
}
