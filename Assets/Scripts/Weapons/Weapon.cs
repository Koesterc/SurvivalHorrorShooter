using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BaseWeapon {
    public float lastShot { get; private set; }
    Transform muzzle;
    static LineRenderer lineRenderer;
    IEnumerator wait2;

    // Use this for initialization
    void Start () {
        wait2 = Wait2();
        //getting the weapon's muzzle
        muzzle = transform.Find("Muzzle");
        sounds.gunShot = transform.Find("Sounds/Gunshot").gameObject.GetComponent<AudioController>();
        sounds.empty = transform.Find("Sounds/Empty").gameObject.GetComponent<AudioController>();
        sounds.reload = transform.Find("Sounds/Reload").gameObject.GetComponent<AudioController>();
        sounds.bulletDrop = transform.Find("Sounds/BulletDrop").gameObject.GetComponent<AudioController>();
        particles.muzzleFlash = transform.Find("Particles/MuzzleFlash").gameObject;
        lineRenderer = transform.parent.gameObject.GetComponent<LineRenderer>();
        ammo = capacity.maxCapacity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Fire()
    {
        //assigning the coroutine
        StopCoroutine(wait2);
        wait2 = Wait2();
        StartCoroutine(wait2);

        lastShot = Time.time+fireRate.maxFireRate;
        sounds.gunShot.Play();
        int hits = 0;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, muzzle.position);
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(hits, muzzle.position);
        particles.muzzleFlash.SetActive(true);

        RaycastHit hit;

        muzzle.rotation = Quaternion.Euler(muzzle.localRotation.x + UnityEngine.Random.Range(-handling.accuracy, +handling.accuracy),
            muzzle.localRotation.x + UnityEngine.Random.Range(-handling.accuracy, +handling.accuracy), muzzle.localRotation.z);

        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, handling.range))
        {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(hit.normal * -firePower.force);
                }
            if (hit.transform.gameObject.GetComponent<Health>() != null)
                hit.transform.gameObject.GetComponent<Health>().TakeDamage(firePower.maxDamage);
        }
        lineRenderer.SetPosition(hits+1, muzzle.forward * handling.range);
        muzzle.rotation = Quaternion.identity;
        StartCoroutine(wait());
    }
    IEnumerator wait()
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

    }
}
