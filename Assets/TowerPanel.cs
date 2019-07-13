using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : MonoBehaviour
{
    [SerializeField] GameObject TowerInfoPanel;
    [SerializeField] Player Player;
    float rangeCur;
    float damageCur;
    int lvlCur;
    int idCur;
    Text TowerText;
    GameObject lastTower;

    // Start is called before the first frame update
    void Start()
    {
        TowerInfoPanel = this.gameObject.transform.GetChild(0).gameObject;

        TowerInfoPanel.SetActive(false);

        TowerText = TowerInfoPanel.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnPanel(float range, float damage, int level, int id, GameObject Tower)
    {
        
        if (TowerInfoPanel.activeSelf == true && id == idCur && level == lvlCur) 
        {
            //  gameObject.SetActive(false);
            TowerInfoPanel.SetActive(false);
        }

        else
        {
            TowerInfoPanel.SetActive(true);
            idCur = id;
            lvlCur = level;
            TowerText.text = "Range: " + range.ToString() + "\n" 
                + "Damage: " + damage.ToString() + "\n"
                + "Level: " + level.ToString() + "\n";
            lastTower = Tower;


        }
    }

    public void sellTower()
    {
        Destroy(lastTower);
        Player.SetCoins(Player.GetCoins() + lastTower.GetComponent<TowerScript>().getTowerPrice());
        TowerInfoPanel.SetActive(false);
    }
}
