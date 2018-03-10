using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, Idamagable {
    [SerializeField]
    float health = 100;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void TakeDamage (float inDamage) {
        health -= inDamage;
        if (health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
        }
    }

     void Idamagable.TakeDamage()
    {
    }
}
