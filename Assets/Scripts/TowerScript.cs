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
    GameObject TowerOfferPanel;
    Level LevelScript;
    float HoldTimer = 0f;

    private Vector3 screenPoint;
    private Vector3 offset;
    bool dragging = false;
    Color TowerColor;
    Color OldColor;
    Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        TowerInfo = GameObject.FindWithTag("TowerInfo");
        Level = GameObject.FindWithTag("Level");
        TowerOfferPanel = GameObject.FindWithTag("TowerOfferPanel");
        TowerPanel = TowerInfo.GetComponent<TowerPanel>();
        LevelScript = Level.GetComponent<Level>();
        TowerColor = gameObject.GetComponent<Renderer>().material.color;
        OldColor = TowerColor;
        oldPosition = transform.position;
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
        HoldTimer += Time.deltaTime;
        if(HoldTimer >= 1)
        {
            dragging = true;
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, LevelScript.getZfield() + 14.5f);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

            transform.position = cursorPosition;
            TowerColor.r = 0.5f;
            gameObject.GetComponent<Renderer>().material.color = TowerColor;

        }
    }

    void OnMouseUp()
    {
        if(dragging == true)
        {
            RaycastHit objectHit;
            Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(gameObject.transform.position, fwd * 50, Color.green);
            if (Physics.Raycast(gameObject.transform.position, fwd, out objectHit, 50))
            {
                Vector3 wordPos = objectHit.point;
                if (objectHit.transform.tag == "PlayField")
                {
                    transform.position = wordPos;
                   // Instantiate(gameObject, wordPos, transform.rotation);
                    LevelScript.SetTower(-1,1);
                    gameObject.GetComponent<Renderer>().material.color = OldColor;
                    oldPosition = transform.position;
                }
                else if(objectHit.transform.tag == "Panel")
                {
                    for (int i = 0; i < TowerOfferPanel.transform.childCount; i++)
                    {
                        GameObject child = TowerOfferPanel.transform.GetChild(i).gameObject;
                        if (child.activeSelf == false)
                        {
                            GameObject Tower = Level.GetComponent<Level>().GetTowerByNum(id);
                            Level.GetComponent<Level>().TowerBought(id);
                            Button button = child.GetComponent<Button>();
                            button.GetComponentInChildren<Text>().text = (id).ToString();
                            button.GetComponent<ButtonScript>().setTowerNumber(id, level);
                            child.SetActive(true);
                            Destroy(gameObject);
                            break;
                        }
                        if(i == TowerPanel.transform.childCount - 1)
                        {
                            transform.position = oldPosition;
                            gameObject.GetComponent<Renderer>().material.color = OldColor;
                        }

                    }
                }
                else
                {
                    transform.position = oldPosition;
                    gameObject.GetComponent<Renderer>().material.color = OldColor;
                }

            }
            HoldTimer = 0;
            dragging = false;

        }
    }
    
    public int getId()
    {
        return id;
    }

    public float getTowerPrice()
    {
        return TowerPrice;
    }
}
