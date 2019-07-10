using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManage : MonoBehaviour
{
    [SerializeField] int valmin = 1;
    [SerializeField] int valmax = 5;
    [SerializeField] GameObject TowerPanel;
    [SerializeField] GameObject panel;
    [SerializeField] EnemyControl EnemyControl;

    int BoughtTower;
    int wave = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in TowerPanel.transform)
        {
            child.gameObject.SetActive(false); 
        }
        panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
        if (wave == EnemyControl.getWave())
        {

            foreach(Transform child in panel.transform)
            {
                if(child.gameObject.activeSelf == false)
                {
                    child.gameObject.SetActive(true);
                }

                Button button = child.gameObject.GetComponent<Button>();

                int value = Random.Range(valmin, valmax);
                button.GetComponentInChildren<Text>().text = value.ToString();
                button.GetComponent<ButtonScript>().setTowerNumber(value);
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
    

}
