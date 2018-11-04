using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class birbScrip : MonoBehaviour {
    public float lastHeight;
    public float lastHorizontal;
    public bool isDead;

    public GameObject myTarget;


	// Use this for initialization
	void Start () {
        isDead = false;
        lastHeight = 0;
        lastHorizontal = 0;
        updateHeight();
	}
	
	// Update is called once per frame
	void Update () {
        if(isDead==false)
        {
            try
            {
                this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(myTarget.transform.position.x - 2, myTarget.transform.position.y, myTarget.transform.position.z), 9f);
            }
            catch
            {
                birbdie();
                Debug.Log("Exception logged, killing a bird");
            }
        }

        if(this.transform.position.y > lastHeight && isDead == false)
        {
            this.GetComponent<Animator>().Play("birb_fly");
        }
        if (this.transform.position.y < lastHeight && isDead == false)
        {
            this.GetComponent<Animator>().Play("birb_hover");
        }
        if(this.transform.position.x < lastHorizontal)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
	}

    void updateHeight()
    {
        lastHeight = this.transform.position.y;
        lastHorizontal = this.transform.position.x;
        Invoke("updateHeight", 0.3f);
    }

    public void birbdie()
    {
        isDead = true;
        this.GetComponent<Animator>().Play("birb_die");
        this.GetComponent<Rigidbody2D>().simulated = true;
    }
}
