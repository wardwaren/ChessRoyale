using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] float coins = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GetHit(int damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetCoins()
    {
        return coins;
    }
}
