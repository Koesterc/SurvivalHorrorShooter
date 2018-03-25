using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : BaseHealth, Idamagable
{
	public override void TakeDamage (float inDamage) {
        inDamage = AdditionalDamage(inDamage);
        coreHealth.TakeDamage(inDamage);
        print("Worked");
    }

    public float AdditionalDamage(float value)
    {
        switch (bodyPart) {
            default:
                print("core");
                break;
            case BodyPart.Torso:
                print("torso");
                break;
            case BodyPart.Limb:
                print("limb");
                value *= .5f;
                break;
            case BodyPart.Head:
                print("head");
                value *= 5f;
                break;
        }
        return value;

    }

     void Idamagable.TakeDamage()
    {
    }
}
