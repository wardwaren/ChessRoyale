using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    //Configuration parameters
    [Header("Tower")]
    [SerializeField] float range = 10f;
    [SerializeField] float damage = 200f;

    [Header("Projectile")]
    [SerializeField] GameObject TowerProj;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
