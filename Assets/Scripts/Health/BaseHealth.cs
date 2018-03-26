using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour, Idamagable {
    public enum BodyPart {Head, Torso, Core, Limb, LeftLeg, RightLeg};
    public BodyPart bodyPart;
    public CoreHealth coreHealth;

    // Update is called once per frame
    public virtual void TakeDamage(float inDamage)
    {

    }

     void Idamagable.TakeDamage()
    {
    }
}
