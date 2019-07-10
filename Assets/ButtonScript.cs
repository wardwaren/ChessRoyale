using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{


    GameObject Level;
    GameObject TowerPanel;

    int TowerNumber = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        TowerPanel = GameObject.Find("TowerPanel");
        Level = GameObject.Find("Level");
    }


    public void TurnOffButton()
    {
       if(Level.GetComponent<Level>().getTower() == null)
       {
            gameObject.SetActive(false);
        }
    }

    public void setTowerNumber(int num)
    {
        TowerNumber = num;
    }

    public int getTowerNumber()
    {
        return TowerNumber;
    }

    public void setCurrentTower()
    {
        Level.GetComponent<Level>().SetTower(TowerNumber);
    }

    public void AssignValue()
    {
        for (int i = 0; i < TowerPanel.transform.childCount; i++)
        {
            /// All your stuff with transform.GetChild(i) here...
            GameObject child = TowerPanel.transform.GetChild(i).gameObject;

            if (child.activeSelf == false)
            {

                Button button = child.GetComponent<Button>();
                button.GetComponentInChildren<Text>().text = TowerNumber.ToString();
                button.GetComponent<ButtonScript>().setTowerNumber(TowerNumber);
                child.SetActive(true);
                break;
            }
        }
    }
}
