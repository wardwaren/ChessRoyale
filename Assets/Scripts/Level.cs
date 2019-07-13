using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] List<GameObject> towers;
    [SerializeField] GameObject playField;

    Dictionary<int, int> OwnedTowers = new Dictionary<int, int>();
    GameObject currentTower = null;
    float zPositionField;

    // Start is called before the first frame update
    void Start()
    {
        zPositionField = playField.transform.position.z;
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

        if (OwnedTowers.TryGetValue(TowerNumber, out value))
        {
            OwnedTowers[TowerNumber]++;
        }
        else
        {
            OwnedTowers.Add(TowerNumber, 1);
        }
    }

    public float getZfield()
    {
        return zPositionField;
    }

    public void CreateTower(GameObject Tower)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            string tag = hit.collider.gameObject.tag;
            Debug.Log(hit.point);
            Vector3 wordPos = hit.point;
            Debug.Log(name);

            if (tag == "PlayField")
            {
                Instantiate(Tower, wordPos, transform.rotation);
                currentTower = null;
            }
        }
    }
}
