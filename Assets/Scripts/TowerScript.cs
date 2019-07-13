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

    [SerializeField] GameObject Level;

    GameObject TowerInfo;
    TowerPanel TowerPanel;
    Level LevelScript;

    private Vector3 screenPoint;
    private Vector3 offset;
    bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {
        TowerInfo = GameObject.FindWithTag("TowerInfo");
        Level = GameObject.FindWithTag("Level");
        TowerPanel = TowerInfo.GetComponent<TowerPanel>();
        LevelScript = Level.GetComponent<Level>();
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
        dragging = false;
        TowerPanel.TurnPanel(range,damage,level,id, gameObject);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        dragging = true;
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, LevelScript.getZfield() + 15f);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    void OnMouseUp()
    {
        if(dragging == true)
        {
            Destroy(gameObject);
            LevelScript.SetTower(id + 1);
        }
    }

    public float getTowerPrice()
    {
        return TowerPrice;
    }
}
