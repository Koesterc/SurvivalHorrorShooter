using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHealth : MonoBehaviour, Idamagable {
    public enum BodyPart {Head, Torso, Core, Limb };
    public BodyPart bodyPart;
    public CoreHealth coreHealth;

    // Update is called once per frame
    public abstract void TakeDamage(float inDamage);

     void Idamagable.TakeDamage()
    {
    }
}
