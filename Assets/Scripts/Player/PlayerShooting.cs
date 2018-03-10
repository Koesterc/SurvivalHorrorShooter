using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {
    public List<Weapon> weapons = new List<Weapon>();
    int curSelected = 0;
    public Text ammoCount;

	// Use this for initialization
	void Start () {
        Transform firearms = transform.Find("FPS Camera/Weapons");
        foreach (Transform firearm in firearms)
            weapons.Add(firearm.gameObject.GetComponent<Weapon>());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && weapons[curSelected].lastShot <= Time.time)
        {
            if (weapons[curSelected].ammo <= 0)
                return;
            weapons[curSelected].Fire();
            weapons[curSelected].ammo--;
            //displays ammo out of max ammo on the UI (i.e. Ammo: 35/100)
            ammoCount.text = "Ammo: "+weapons[curSelected].ammo.ToString()+"/"+weapons[curSelected].capacity.maxCapacity.ToString();
        }
	}
}
