using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static AmmunitionStorage ammoStorage;
    public static WeaponStorage weaponStorage;
    [SerializeField]
    [Header("Ammo Storage")]
    AmmunitionStorage m_ammoStorage;
    [SerializeField]
    [Header("Weapon Storage")]
    WeaponStorage m_weaponStorage;

    // Use this for initialization
    void Awake()
    {
        ammoStorage = m_ammoStorage;
        weaponStorage = m_weaponStorage;
    }

    [System.Serializable]
    public class AmmunitionStorage
    {
        public HandgunBullets hgBullets;
        public ShotgunShells sgShells;
        public SMGBullets smgBullets;
        public ARBullets arBullets;
        public SniperRounds sniperRounds;
        public MagnumRounds magnumRounds;


        [System.Serializable]
        public class HandgunBullets
        {
            public int maxAmmo;
            public int ammo;
            public int value;

            //evaluates the current amount of ammo
            public int Refill(int value)
            {
                if (ammo <= value)
                    value = ammo;
                ammo -= value;
                if (ammo <= 0)
                    ammo = 0;
                return value;
            }
        }
        [System.Serializable]
        public class ShotgunShells
        {
            public int maxAmmo;
            public int ammo;
            public int value;
            //evaluates the current amount of ammo
            public int Refill(int value)
            {
                if (ammo <= value)
                    value = ammo;
                ammo -= value;
                if (ammo <= 0)
                    ammo = 0;
                return value;
            }
        }
        [System.Serializable]
        public class SMGBullets
        {
            public int maxAmmo;
            public int ammo;
            public int value;
            //evaluates the current amount of ammo
            public int Refill(int value)
            {
                if (ammo <= value)
                    value = ammo;
                ammo -= value;
                if (ammo <= 0)
                    ammo = 0;
                return value;
            }
        }
        [System.Serializable]
        public class ARBullets
        {
            public int maxAmmo;
            public int ammo;
            public int value;

            //evaluates the current amount of ammo
            public int Refill(int value)
            {
                if (ammo <= value)
                    value = ammo;
                ammo -= value;
                if (ammo <= 0)
                    ammo = 0;
                return value;
            }
        }
        [System.Serializable]
        public class SniperRounds
        {
            public int maxAmmo;
            public int ammo;
            public int value;

            //evaluates the current amount of ammo
            public int Refill(int value)
            {
                if (ammo <= value)
                    value = ammo;
                ammo -= value;
                if (ammo <= 0)
                    ammo = 0;
                return value;
            }
        }
        [System.Serializable]
        public class MagnumRounds
        {
            public int maxAmmo;
            public int ammo;
            public int value;

            //evaluates the current amount of ammo
            public int Refill(int value)
            {
                if (ammo <= value)
                    value = ammo;
                ammo -= value;
                if (ammo <= 0)
                    ammo = 0;
                return value;
            }
        }
    }


    [System.Serializable]
    public class WeaponStorage
    {
    }
}

