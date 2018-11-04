using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fetchScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "birbA" || collision.name == "birbB" || collision.name == "birbC" || collision.name == "birbD" || collision.name == "birbE")
        {
            if(collision.GetComponent<birbScrip>().isDead == true)
            {
                GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().caught = GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().caught + 1;
            }
            Destroy(collision.gameObject);
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().countTargets();
        }

        if (collision.name == "target_a")
        {
            Destroy(collision.gameObject);
            Debug.Log("fallen A");
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().targetAout = false;
            GameObject.Find("Doggeh").GetComponent<Animator>().Play("doggeh_laugh");
            Destroy(GameObject.Find("birbA").gameObject);
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives = GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives - 1;
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().Invoke("countTargets", 3f);
            
        }
        if (collision.name == "target_b")
        {
            Destroy(collision.gameObject);
            Debug.Log("fallen B");
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().targetBout = false;
            GameObject.Find("Doggeh").GetComponent<Animator>().Play("doggeh_laugh");
            Destroy(GameObject.Find("birbB").gameObject);
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives = GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives - 1;
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().Invoke("countTargets", 3f);

        }
        if (collision.name == "target_c")
        {
            Destroy(collision.gameObject);
            Debug.Log("fallen C");
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().targetCout = false;
            GameObject.Find("Doggeh").GetComponent<Animator>().Play("doggeh_laugh");
            Destroy(GameObject.Find("birbC").gameObject);
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives = GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives - 1;
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().Invoke("countTargets", 3f);

        }
        if (collision.name == "target_d")
        {
            Destroy(collision.gameObject);
            Debug.Log("fallen D");
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().targetDout = false;
            GameObject.Find("Doggeh").GetComponent<Animator>().Play("doggeh_laugh");
            Destroy(GameObject.Find("birbD").gameObject);
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives = GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives - 1;
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().Invoke("countTargets", 3f);

        }
        if (collision.name == "target_e")
        {
            Destroy(collision.gameObject);
            Debug.Log("fallen E");
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().targetEout = false;
            GameObject.Find("Doggeh").GetComponent<Animator>().Play("doggeh_laugh");
            Destroy(GameObject.Find("birbE").gameObject);
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives = GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().lives - 1;
            GameObject.Find("ScriptHolder").GetComponent<SpawnScript>().Invoke("countTargets", 3f);
        }
    }


}
