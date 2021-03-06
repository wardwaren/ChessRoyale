﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] public int timeBetweenWaves = 30;
    [SerializeField] int numOfWaves = 2;

    bool started = false;
    int time = 30;
    int numOfEnemies = 0;
    int currentWave = -1;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        time = timeBetweenWaves;
        do
        {
            yield return new WaitForSeconds(1);
            if (started == false)
            {
                currentWave++;
                for (int i = 0; i < timeBetweenWaves; i++)
                {
                    yield return new WaitForSeconds(1);
                    time--;
                }
                Debug.Log(currentWave);
                
                numOfWaves--;


                started = true;
            }
            else
            {
                if(numOfEnemies == 0)
                {
                    started = false;
                    time = timeBetweenWaves;
                }

            }
        } while (numOfWaves != 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }


    public bool getStarted()
    {
        return started;
    }
    
    public void setStarted(bool state)
    {
        started = state;
    }

    public int getWave()
    {
        return currentWave;
    }

    public int getTime()
    {
        return time;
    }

}
