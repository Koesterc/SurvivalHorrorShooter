using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat: MonoBehaviour {
    public List<BaseWeapon> weapons;
    int curSelected = 2;
    public Text ammoCount;
    bool canShoot = true;
    float lastShot;

    // Use this for initialization
    void Start () {
        Transform firearms = transform.Find("FPS Camera/Weapons");
        foreach (Transform firearm in firearms)
            weapons.Add(firearm.gameObject.GetComponent<BaseWeapon>());
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && lastShot <= Time.time)
        {
            lastShot = Time.time + weapons[curSelected].fireRate.maxFireRate;
            if (!canShoot || weapons[curSelected].capacity.ammo <= 0)
                return;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && weapons[curSelected].capacity.ammo < weapons[curSelected].capacity.maxCapacity && weapons[curSelected].Ammo() > 0 && canShoot)
            StartCoroutine(Reload());

    }
        
    IEnumerator Reload()
    {//reloading the weapon
        weapons[curSelected].sounds.reload.Play();
        canShoot = false;
        yield return new WaitForSeconds(weapons[curSelected].reload.maxReload);
        weapons[curSelected].Reload();
        canShoot = true;
    }


    public void Shoot()
    {
        weapons[curSelected].Fire();
    }
}
