﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour {

    public int level;
    public string weaponName;
    public string desc;
    public enum Type { Handgun, SubMachineGun, AssaultRifle, SniperRifle, Shotgun, Magnum };
    public Type type;
    public Sprite weaponIcon;
    [Space(5)]
    public FirePower firePower;
    [Space(5)]
    public Capacity capacity;
    [Space(5)]
    public Reload reload;
    [Space(5)]
    public FireRate fireRate;
    [Space(5)]
    public Handling handling;
    [HideInInspector]
    public Sounds sounds;
    [HideInInspector]
    public Particles particles;
    public abstract void Fire();
    public abstract void Reload();
    public abstract int Ammo();
    public abstract void DisplayAmmo();
}

[System.Serializable]
public class FirePower
{
    public enum DamageType { Normal, Scattershot, BurstFire, Explosive };
    public DamageType damageType;
    [Range(1,10)]
    public int shotsPerFire = 1;
    public float maxDamage;
    public float force;
    [Space(5)]
    public Upgrades upgrades;
    [System.Serializable]
    public class Upgrades
    {
        public float maxDamage;
        [Range(1,10)]
        public int maxUpgrade;
        [HideInInspector]
        public int curUpgrade { get; private set; }
        public int cost;
    }
}

[System.Serializable]
public class Capacity
{
    [HideInInspector]
    public int ammo;
    public int maxCapacity;
    [Space(5)]
    public Upgrades upgrades;
    [System.Serializable]
    public class Upgrades
    {
        public int capacity = 10;
        [Range(1, 10)]
        public int maxUpgrade;
        [HideInInspector]
        public int curUpgrade { get; private set; }
        public int cost;
    }
}

[System.Serializable]
public class Reload
{
    public float maxReload;
    [Space(5)]
    public Upgrades upgrades;
    [System.Serializable]
    public class Upgrades
    {
        public int maxReload = 3;
        [Range(1, 10)]
        public int maxUpgrade;
        [HideInInspector]
        public int curUpgrade { get; private set; }
        public int cost;
    }
}

[System.Serializable]
public class FireRate
{
    public float maxFireRate = 1;
    [Space(5)]
    public Upgrades upgrades;
    [System.Serializable]
    public class Upgrades
    {
        public int maxFireRate;
        [Range(1, 10)]
        public int maxUpgrade;
        [HideInInspector]
        public int curUpgrade { get; private set; }
        public int cost;
    }
}

[System.Serializable]
public class Handling
{
    [TooltipAttribute("Bullet Spread")]
    [Range(0,100)]
    public int accuracy = 30;
    [TooltipAttribute("The length at which the bullet travels")]
    [Range(0, 100)]
    public int range = 100;
    [TooltipAttribute("The maximum zoom for the weapon's scope")]
    [Range(0, 1)]
    public float zoom = .2f;
    [TooltipAttribute("How much the weapon recoils when firing")]
    [Range(0, 1)]
    public float recoil = .2f;
}

[System.Serializable]
public class Sounds{
    public AudioController gunShot;
    public AudioController reload;
    public AudioController empty;
    public AudioController bulletDrop;
}

[System.Serializable]
public class Particles
{
    public GameObject muzzleFlash;
    public GameObject smoke;
    public GameObject bulletDrop;
}