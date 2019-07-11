using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class TowerPanel : MonoBehaviour
{
    [SerializeField] GameObject TowerInfoPanel;

    float rangeCur;
    float damageCur;
    int lvlCur;
    int idCur;
    Canvas cg;

    // Start is called before the first frame update
    void Start()
    {
        TowerInfoPanel = this.gameObject.transform.GetChild(0).gameObject;

        TowerInfoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnPanel(float range, float damage, int level, int id)
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
        }
    }
}
