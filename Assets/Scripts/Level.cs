using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] List<GameObject> towers1;
    [SerializeField] List<GameObject> towers2;
    [SerializeField] List<GameObject> towers3;
    [SerializeField] GameObject playField;
    [SerializeField] GameObject panel;

 
    List<Dictionary<int, int>> OwnedTowers = new List<Dictionary<int, int>>();
    Dictionary<int, int> OwnedTowers1 = new Dictionary<int, int>();
    Dictionary<int, int> OwnedTowers2 = new Dictionary<int, int>();
    Dictionary<int, int> OwnedTowers3 = new Dictionary<int, int>();
    GameObject currentTower = null;
    float zPositionField;

    // Start is called before the first frame update
    void Start()
    {
        zPositionField = playField.transform.position.z;
        OwnedTowers.Add(OwnedTowers1);
        OwnedTowers.Add(OwnedTowers2);
        OwnedTowers.Add(OwnedTowers3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && currentTower != null)
        {

            CreateTower(currentTower);
        }
    }

    public GameObject getTower()
    {
        return currentTower;
    }

    public void SetTower(int num, int lvl)
    {
        if (num >= 0)
        {
            if(lvl == 1)
            {
                currentTower = towers1[num];
            }
            else if(lvl == 2)
            {
                currentTower = towers2[num];
            }
            else if(lvl == 3)
            {
                currentTower = towers3[num];
            }
        }
        else
        {
            currentTower = null;
        }
    }

    public GameObject GetTowerByNum(int TowerNumber)
    {
        return towers1[TowerNumber];
    }

    public void TowerBought(int TowerNumber)
    {
        int value;

        if (OwnedTowers[0].TryGetValue(TowerNumber, out value))
        {
            OwnedTowers[0][TowerNumber]++;
            if (OwnedTowers[0][TowerNumber] == 3)
            {

                ManageTower(TowerNumber, 1);

                if (OwnedTowers[1].TryGetValue(TowerNumber, out value))
                {
                    OwnedTowers[1][TowerNumber]++;
                    if (OwnedTowers[1][TowerNumber] == 3)
                    {
                        ManageTower(TowerNumber, 2);
                    }
                }

                else
                {
                    OwnedTowers[1].Add(TowerNumber, 1);
                }
            }
        }
        else
        {
            OwnedTowers[0].Add(TowerNumber, 1);
        }
    }

    public void ManageTower(int TowerNumber, int TowerLevel)
    {
        OwnedTowers[TowerLevel - 1][TowerNumber] = 0;

        int count = 0;
        foreach (Transform child in panel.transform)
        {

            int number = child.GetComponent<ButtonScript>().getTowerNumber();
            int lvl = child.GetComponent<ButtonScript>().getTowerLevel();

            if (number == TowerNumber && lvl == TowerLevel)
            {
                Debug.Log("HERE");
                Debug.Log(TowerLevel);
                Debug.Log(lvl);
                Debug.Log("THERE");
                if (count == 0)
                {
                    child.gameObject.GetComponent<ButtonScript>().setTowerNumber(TowerNumber, TowerLevel + 1);
                }
                else
                {
                    child.gameObject.GetComponent<ButtonScript>().TurnOffButton();
                }
                count++;
            }
        }
    }

    public float getZfield()
    {
        return zPositionField;
    }

    public void CreateTower(GameObject Tower)
    {
        Debug.Log(Tower);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            string tag = hit.collider.gameObject.tag;
            Vector3 wordPos = hit.point;

            if (tag == "PlayField")
            {
                Instantiate(Tower, wordPos, transform.rotation);
                currentTower = null;
            }

        }
    }
}
