using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int curAmmo;
    public AmmunitionStorage ammounitionStorage;
    WeaponStorage weaponStorage;
    // Use this for initialization
    void Start()
    {

    }
}
    [System.Serializable]
    public class AmmunitionStorage
    {
        public int maxAmmo;
        public int ammo;
        public string ammoType;
    

        //evaluates the current amount of ammo
        public int Ammo(int value) {
            if (ammo <= value)
                value = ammo;
            ammo -= value;
            if (ammo <= 0)
                ammo = 0;
            return value;
        }
    }

    public class Bullets{
    public BaseWeapon.Type ammoType;
    public int maxAmmo;
    public int ammo;
    public int value;
}

    [System.Serializable]
    public class WeaponStorage
    {
    }

