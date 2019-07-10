using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] float coins = 1f;

    EnemyControl EnemyControl;
    int wave = 0;
    float prevhp = 100f;
    float winstreak = 0f;
    float losestreak = 0f;

    // Start is called before the first frame update
    void Start()
    {
        prevhp = health;
        EnemyControl = FindObjectOfType<EnemyControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     if(wave == EnemyControl.getWave())
        {
            if(coins <= 50)
            {
                if (prevhp == health)
                {
                    losestreak = 0;
                    winstreak++;
                }
                else
                {
                    winstreak = 0;
                    losestreak++;
                }

                if (wave == 0)
                {
                    coins += 1;
                }
                else if (wave == 1)
                {
                    coins += 2;
                }
                else
                {
                    coins += 5 + winstreak + losestreak + Mathf.Floor(coins * 0.1f);
                }
                wave++;
            }
            
        }   
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

    public void SetCoins(float val)
    {
        coins = val;
    }
}
