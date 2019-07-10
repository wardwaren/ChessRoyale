using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{


    [SerializeField] GameObject Level;
    [SerializeField] GameObject TowerPanel;
    [SerializeField] GameObject Player;

    int TowerNumber = 0;
   
    // Start is called before the first frame update
    void Start()
    {

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
            GameObject child = TowerPanel.transform.GetChild(i).gameObject;

            if (child.activeSelf == false)
            {
                //Get tower by the number and reduce amount of coins according to price.
                GameObject Tower = Level.GetComponent<Level>().GetTowerByNum(TowerNumber);
                float price = Tower.GetComponentInChildren<TowerScript>().getPrice();
                float coins = Player.GetComponent<Player>().GetCoins();
                if (coins >= price)
                {
                    Level.GetComponent<Level>().TowerBought(TowerNumber);
                    Player.GetComponent<Player>().SetCoins(coins - price);
                    Button button = child.GetComponent<Button>();
                    button.GetComponentInChildren<Text>().text = TowerNumber.ToString();
                    button.GetComponent<ButtonScript>().setTowerNumber(TowerNumber);
                    child.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;
            }
        }
    }
}
