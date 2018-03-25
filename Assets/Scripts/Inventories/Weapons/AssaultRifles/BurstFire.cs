using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFire : AssaultRifle
{
    static LineRenderer lineRenderer;
    IEnumerator wait2;
    bool canFire = true;

    // Use this for initialization
    void Start()
    {
        wait2 = Wait2();
        //getting the weapon's muzzle
        muzzle = transform.Find("Muzzle");
        sounds.gunShot = transform.Find("Sounds/Gunshot").gameObject.GetComponent<AudioController>();
        sounds.empty = transform.Find("Sounds/Empty").gameObject.GetComponent<AudioController>();
        sounds.reload = transform.Find("Sounds/Reload").gameObject.GetComponent<AudioController>();
        sounds.bulletDrop = transform.Find("Sounds/BulletDrop").gameObject.GetComponent<AudioController>();
        particles.muzzleFlash = transform.Find("Particles/MuzzleFlash").gameObject;
        lineRenderer = transform.parent.gameObject.GetComponent<LineRenderer>();
        //the ammo for this weapon that is stored
        ammoStorage = Inventory.ammoStorage.arBullets;
        capacity.ammo = capacity.maxCapacity;
    }

    void OnEnable()
    {
    }

    public override void Fire()
    {
        if (!canFire)
            return;
        canFire = false;
        StartCoroutine(Burst());
    }

    IEnumerator Burst()
    {
        for(int i = 0; i < firePower.shotsPerFire; i++)
        {
            if (capacity.ammo < 1)
            {
                canFire = true;
                yield return null;
            }
            yield return new WaitForSeconds(.065f);
            //subtracts from ammo and displays ammo out of max ammo on the UI (i.e. Ammo: 35/100)
            capacity.ammo--;
            if (capacity.ammo <= 0)
                capacity.ammo = 0;
            DisplayAmmo();

            //assigning the coroutine
            StopCoroutine(wait2);
            wait2 = Wait2();
            StartCoroutine(wait2);

            sounds.gunShot.Play();
            int hits = 0;
            lineRenderer.positionCount = firePower.shotsPerFire + 1;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(hits, muzzle.position);
            particles.muzzleFlash.SetActive(true);

            RaycastHit hit;

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
            lineRenderer.SetPosition(hits + 1, muzzle.right * handling.range);
            muzzle.rotation = Quaternion.identity;
            StartCoroutine(Wait());
        }
        canFire = true;
    }

    IEnumerator Wait()
    {
        yield return null;
        lineRenderer.enabled = false;
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(.1f);
        particles.muzzleFlash.SetActive(false);
    }

    public override void Reload()
    {
        //refilling the ammo
        capacity.ammo += ammoStorage.Refill(capacity.maxCapacity - capacity.ammo);
        DisplayAmmo();
    }

    public override void DisplayAmmo()
    {
        //updating the current ammo for the HUD
        GameManager.ui.texts.ammoCount.text = "Ammo: " + capacity.ammo.ToString() + "/" + ammoStorage.ammo.ToString();
    }

    public override int Ammo()
    {
        return ammoStorage.ammo;
    }
}
