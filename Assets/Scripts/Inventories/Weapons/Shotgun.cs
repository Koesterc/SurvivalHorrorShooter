using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWeapon
{
    [HideInInspector]
    public Inventory.AmmunitionStorage.ShotgunShells ammoStorage { get; private set; }
    Transform muzzle;
    static LineRenderer lineRenderer;
    IEnumerator wait2;

    [SerializeField]
    GameObject smoke;
    [SerializeField]
    GameObject sgSmoke;

    // Use this for initialization
    void Start()
    {
        //getting the weapon's muzzle
        muzzle = transform.Find("Muzzle");
        sounds.gunShot = transform.Find("Sounds/Gunshot").gameObject.GetComponent<AudioController>();
        sounds.empty = transform.Find("Sounds/Empty").gameObject.GetComponent<AudioController>();
        sounds.reload = transform.Find("Sounds/Reload").gameObject.GetComponent<AudioController>();
        sounds.bulletDrop = transform.Find("Sounds/BulletDrop").gameObject.GetComponent<AudioController>();
        particles.muzzleFlash = transform.Find("Particles/MuzzleFlash").gameObject;
        lineRenderer = transform.parent.gameObject.GetComponent<LineRenderer>();
        //the ammo for this weapon that is stored
        ammoStorage = Inventory.ammoStorage.sgShells;
        capacity.ammo = capacity.maxCapacity;
    }

    void OnEnable()
    {
    }

    public override void Fire()
    {
        //subtracts from ammo and displays ammo out of max ammo on the UI (i.e. Ammo: 35/100)
        capacity.ammo--;
        GameManager.ui.texts.ammoCount.text = "Ammo: " + capacity.ammo.ToString() + "/" + ammoStorage.ammo.ToString();

        sounds.gunShot.Play();

        RaycastHit hit;

        for (int i = 0; i < firePower.shotsPerFire; i++)
        {
            muzzle.localRotation = Quaternion.Euler(0,
            muzzle.rotation.x + UnityEngine.Random.Range(-handling.accuracy, +handling.accuracy),
            muzzle.rotation.z + UnityEngine.Random.Range(-handling.accuracy, +handling.accuracy));

            if (Physics.Raycast(muzzle.position, muzzle.right, out hit, handling.range))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(hit.normal * -firePower.force);
                }
                if (hit.transform.gameObject.GetComponent<Health>() != null)
                    hit.transform.gameObject.GetComponent<Health>().TakeDamage(firePower.maxDamage);

                Destroy(Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal)), 3f);
            }
            muzzle.rotation = Quaternion.identity;
        }
        Destroy(Instantiate(sgSmoke, muzzle.position, muzzle.rotation),1f);
    }

    public override void Reload()
    {
        //refilling the ammo
        capacity.ammo += ammoStorage.Refill(capacity.maxCapacity - capacity.ammo);
        //updating the current ammo for the HUD
        GameManager.ui.texts.ammoCount.text = "Ammo: " + capacity.ammo.ToString() + "/" + ammoStorage.ammo.ToString();
    }
    public override int Ammo()
    {
        return ammoStorage.ammo;
    }
}
