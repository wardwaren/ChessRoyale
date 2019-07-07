using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();

    }

    private void OnTriggerEnter(Collider collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        int damage = enemy.getDamage();
        player.GetHit(damage);

    }
}
