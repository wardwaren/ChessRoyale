using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] List<GameObject> towers;

    GameObject playField;
    GameObject currentTower = null;
    float zPositionField;

    // Start is called before the first frame update
    void Start()
    {
        playField = GameObject.Find("PlayField");
        zPositionField = playField.transform.position.z;
        Debug.Log(playField.transform.position);
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
                }
            }

        }
         
    }
    

    public void SetTower(int num)
    {
        currentTower = towers[num];
    }
}
