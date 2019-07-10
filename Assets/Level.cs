using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] List<GameObject> towers;

    Dictionary<int, int> OwnedTowers = new Dictionary<int, int>();
    GameObject playField;
    GameObject currentTower = null;
    float zPositionField;

    // Start is called before the first frame update
    void Start()
    {
        playField = GameObject.Find("PlayField");
        zPositionField = playField.transform.position.z;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && currentTower != null)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,1000f))
            {
                string name = hit.collider.gameObject.name;
                Debug.Log(hit.point);
                Vector3 wordPos = hit.point;
                Debug.Log(name);

                if(name == "PlayField")
                {
                    Instantiate(currentTower, wordPos, transform.rotation);
                    currentTower = null;

                }
            }

        }

         
    }
    
    public GameObject getTower()
    {
        return currentTower;
    }

    public void SetTower(int num)
    {
        currentTower = towers[num];
    }

    public GameObject GetTowerByNum(int TowerNumber)
    {
        return towers[TowerNumber];
    }

    public void TowerBought(int TowerNumber)
    {
        int value;
    
        if(OwnedTowers.TryGetValue(TowerNumber, out value))
        {
            OwnedTowers[TowerNumber]++;
        }
        else
        {
            OwnedTowers.Add(TowerNumber, 1);
        }
    }

}
