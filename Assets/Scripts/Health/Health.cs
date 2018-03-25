using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : BaseHealth, Idamagable
{
	public override void TakeDamage (float inDamage) {
        inDamage = AdditionalDamage(inDamage);
        coreHealth.TakeDamage(inDamage);
    }

    public float AdditionalDamage(float value)
    {
        switch (bodyPart) {
            default:
                break;
            case BodyPart.Torso:
                break;
            case BodyPart.Limb:
                value *= .5f;
                break;
            case BodyPart.Head:
                value *= 2f;
                break;
        }
        return value;

    }

     void Idamagable.TakeDamage()
    {
    }
}
