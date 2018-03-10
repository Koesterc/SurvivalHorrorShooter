using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat: MonoBehaviour {
    public List<Weapon> weapons = new List<Weapon>();
    int curSelected = 0;
    public Text ammoCount;
    bool canShoot = true;
    public Inventory inventory;

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
            if (!canShoot || weapons[curSelected].capacity.ammo <= 0)
                return;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && weapons[curSelected].capacity.ammo < weapons[curSelected].capacity.maxCapacity && inventory.ammounitionStorage.ammo > 0 && canShoot)
            StartCoroutine(Reload());

    }
        
    IEnumerator Reload()
    {
        weapons[curSelected].sounds.reload.Play();
        canShoot = false;
        yield return new WaitForSeconds(weapons[curSelected].reload.maxReload);
        weapons[curSelected].capacity.ammo += inventory.ammounitionStorage.Ammo(weapons[curSelected].capacity.maxCapacity - weapons[curSelected].capacity.ammo);
        canShoot = true;
        ammoCount.text = "Ammo: " + weapons[curSelected].capacity.ammo.ToString() + "/" + inventory.ammounitionStorage.ammo;
    }


    public void Shoot()
    {
        weapons[curSelected].Fire();
        weapons[curSelected].capacity.ammo--;
        //displays ammo out of max ammo on the UI (i.e. Ammo: 35/100)
        ammoCount.text = "Ammo: " + weapons[curSelected].capacity.ammo.ToString() + "/"+inventory.ammounitionStorage.ammo;
    }
}
