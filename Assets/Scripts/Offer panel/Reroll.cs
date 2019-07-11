using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reroll : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TowerManage TowerManage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RerollTowers()
    {
        float PlayerCoins = player.GetCoins();
        player.SetCoins(PlayerCoins - 2f);
        TowerManage.GetComponent<TowerManage>().RandomizeTowers();
        if(TowerManage.GetComponent<TowerManage>().getLock() == true)
        {
            TowerManage.GetComponent<TowerManage>().setLock();
        }
       
    }
}
