using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {
    public Transform target;
    public float speed;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(target.position, this.transform.position) < 10)
        {
            Seek();
        }
        else
            Idle();
    }

    void Seek()
    {
        Vector3 direction = target.position - this.transform.position;
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                  Quaternion.LookRotation(direction), 1*Time.deltaTime);
        anim.SetBool("isIdle", false);
        if (direction.magnitude > 1)
        {
            this.transform.Translate(0, 0, speed*Time.deltaTime);
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
        }
    }

    void Idle()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", false);
    }
}
