using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHealth: MonoBehaviour
{
    public float health = 100;
    public GameObject ragDoll;

    public void TakeDamage(float inDamage)
    {
        health -= inDamage;
        if (health <= 0)
        {
            health = 0;
            if (ragDoll){
                GameObject clone = Instantiate(ragDoll, transform.position, transform.rotation);
                clone.name = "Dead";
            }
            gameObject.SetActive(false);
        }
    }
}
