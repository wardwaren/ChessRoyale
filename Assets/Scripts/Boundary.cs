using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField] Player player;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        int damage = enemy.getDamage();
        player.GetHit(damage);

    }
}
