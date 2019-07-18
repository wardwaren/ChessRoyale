using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    
    [SerializeField] GameObject Level;
    [SerializeField] GameObject TowerPanel;
    [SerializeField] GameObject Player;

    int Lvl = 1;
    int TowerNumber = 0;
    int TowerLevel = 1;
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

    public void setTowerNumber(int num, int lvl)
    {
        TowerNumber = num;
        TowerLevel = lvl;
        gameObject.GetComponentInChildren<Text>().text = TowerNumber.ToString() + " " + TowerLevel.ToString();
    }

    public int getTowerNumber()
    {
        return TowerNumber;
    }

    public int getTowerLevel()
    {
        return TowerLevel;
    }
    public void setCurrentTower()
    {
        Level.GetComponent<Level>().SetTower(TowerNumber,TowerLevel);
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
                    Player.GetComponent<Player>().SetCoins(coins - price);
                    Button button = child.GetComponent<Button>();
                    button.GetComponentInChildren<Text>().text = TowerNumber.ToString() + " " + TowerLevel.ToString();
                    button.GetComponent<ButtonScript>().setTowerNumber(TowerNumber, Lvl);
                    child.SetActive(true);
                    gameObject.SetActive(false);
                    Level.GetComponent<Level>().TowerBought(TowerNumber);
                }
                break;
            }
        }
    }
}
