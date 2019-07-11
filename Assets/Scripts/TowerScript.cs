using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
    //Configuration parameters
    [Header("Tower")]
    [SerializeField] float range = 10f;
    [SerializeField] float damage = 200f;
    [SerializeField] float TowerPrice = 1f;
    [SerializeField] int level = 1;
    [SerializeField] int id = 0;

    [Header("Projectile")]
    [SerializeField] GameObject TowerProj;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    GameObject TowerInfo;
    TowerPanel TowerPanel;

    
    // Start is called before the first frame update
    void Start()
    {
        TowerInfo = GameObject.FindWithTag("TowerInfo");
        TowerPanel = TowerInfo.GetComponent<TowerPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getPrice()
    {
        return TowerPrice;
    }

    void OnMouseDown()
    {

        TowerPanel.TurnPanel(range,damage,level,id);
    }
}
