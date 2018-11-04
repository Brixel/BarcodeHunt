using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //<-

public class SpawnScript : MonoBehaviour {
    public int delay = 5;
    public bool targetAout = false;
    public bool targetBout = false;
    public bool targetCout = false;
    public bool targetDout = false;
    public bool targetEout = false;
    public int score = 0;
    public int targets = 1;
    public float power = 1f;
    public GameObject targetA;
    public GameObject targetB;
    public GameObject targetC;
    public GameObject targetD;
    public GameObject targetE;
    private GameObject Doggeh;
    public int lives;
    public int targetsLeft;
    public int Targetteller;
    public bool gameISover;
    public bool quitConfirm;
    public int caught;
    public GameObject birbPrefab;
    public int targetsTODO;



    // Use this for initialization
    void Start () {
        score = 0;
        lives = 6;
        caught = 0;
        gameISover = false;
        quitConfirm = false;
        Doggeh = GameObject.Find("Doggeh");

        // set screen resolution
        int width = 1024; // or something else
        int height = 768; // or something else
        bool isFullScreen = true; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }

    // Update is called once per frame
    void Update()
    {
        //listen for keys to change face
        if (Input.GetKeyUp(KeyCode.A) == true && targetAout == true)
        {
            //hit on A
            GameObject.Find("lightning").GetComponent<Animator>().Play("lightning");
            score = score + 1;
            targetAout = false;           
            Destroy(GameObject.Find("target_a").gameObject);           
            GameObject.Find("birbA").GetComponent<birbScrip>().birbdie();
            Doggeh.transform.position = new Vector3(GameObject.Find("birbA").transform.position.x, Doggeh.transform.position.y, Doggeh.transform.position.z);
            //Invoke("countTargets",3f);
        }
        if (Input.GetKeyUp(KeyCode.B) == true && targetBout == true)
        {
            //hit on B
            GameObject.Find("lightning").GetComponent<Animator>().Play("lightning");
            score = score + 1;
            targetBout = false;
            Destroy(GameObject.Find("target_b").gameObject);
            GameObject.Find("birbB").GetComponent<birbScrip>().birbdie();
            //Invoke("countTargets", 3f);
        }
        if (Input.GetKeyUp(KeyCode.C) == true && targetCout == true)
        {
            //hit on C
            GameObject.Find("lightning").GetComponent<Animator>().Play("lightning");
            score = score + 1;
            targetCout = false;
            Destroy(GameObject.Find("target_c").gameObject);
            GameObject.Find("birbC").GetComponent<birbScrip>().birbdie();
            //Invoke("countTargets", 3f);
        }
        if (Input.GetKeyUp(KeyCode.D) == true && targetDout == true)
        {
            //hit on D
            GameObject.Find("lightning").GetComponent<Animator>().Play("lightning");
            score = score + 1;
            targetDout = false;
            Destroy(GameObject.Find("target_d").gameObject);
            GameObject.Find("birbD").GetComponent<birbScrip>().birbdie();
            //Invoke("countTargets", 3f);
        }
        if (Input.GetKeyUp(KeyCode.E) == true && targetEout == true)
        {
            //hit on E
            GameObject.Find("lightning").GetComponent<Animator>().Play("lightning");
            score = score + 1;
            targetEout = false;
            Destroy(GameObject.Find("target_e").gameObject);
            GameObject.Find("birbE").GetComponent<birbScrip>().birbdie();
            //Invoke("countTargets", 3f);
        }
        if (Input.GetKeyUp(KeyCode.Q) == true)
        {
            GameObject.Find("lightning").GetComponent<Animator>().Play("lightning");
            //quitt'n time
            if (quitConfirm == false)
            {
                quitConfirm = true;
                GameObject.Find("Quitimg").GetComponent<SpriteRenderer>().color = new Color(255f,0f,0f,255f);
            }
            else
            {
                CancelInvoke();
                Application.Quit();
            }

        }
        if (Input.GetKeyUp(KeyCode.N) == true && gameISover == true)
        {
            GameObject.Find("lightning").GetComponent<Animator>().Play("lightning");
            //quitt'n time
            CancelInvoke();
            Application.Quit();
        }
        if (Input.GetKeyUp(KeyCode.Y) == true && gameISover == true)
        {
            GameObject.Find("lightning").GetComponent<Animator>().Play("lightning");
            score = 0;
            lives = 6;
            gameISover = false;
            GameObject.Find("GameOverCanvas").GetComponent<Canvas>().planeDistance = 0;
            CancelInvoke();
            nextGame();
        }
        if (Input.GetKeyUp(KeyCode.S) == true)
        {
            GameObject.Find("lightning").GetComponent<Animator>().Play("lightning");
            score = 0;
            lives = 6;
            gameISover = false;
            GameObject.Find("StartCanvas").GetComponent<Canvas>().planeDistance = 0;
            CancelInvoke();
            nextGame();
        }
        updateGUI();
    }


    public void countTargets()
    {
        CancelInvoke();
        int ammount = 0;
        if(targetAout == true)
        {
            ammount++;
        }
        if (targetBout == true)
        {
            ammount++;
        }
        if (targetCout == true)
        {
            ammount++;
        }
        if (targetDout == true)
        {
            ammount++;
        }
        if (targetEout == true)
        {
            ammount++;
        }
        targetsLeft = ammount;

        if (caught > 0)
        {
            Debug.Log("caught > 0");
            switch (caught)
            {
                case 1:
                    Doggeh.GetComponent<Animator>().Play("doggeh_catch1");
                    break;
                case 2:
                    Doggeh.GetComponent<Animator>().Play("doggeh_catch2");
                    break;
                case 3:
                    Doggeh.GetComponent<Animator>().Play("doggeh_catch3");
                    break;
                case 4:
                    Doggeh.GetComponent<Animator>().Play("doggeh_catch4");
                    break;
                case 5:
                    Doggeh.GetComponent<Animator>().Play("doggeh_catch5");
                    break;
                default:
                    break;
            }

        }
        if (targetsLeft == 0)
        {
            Debug.Log("targets left = 0");
            Invoke("nextGame", 2f);
        }
    }

    void resetLightning()
    {
        GameObject.Find("lightning").GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
    }
    void updateGUI()
    {
        
        // show lives and score
        GameObject.Find("score_text").GetComponent<Text>().text = score.ToString();
        switch (lives)
        {
            case 6:
                GameObject.Find("lives_1").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_2").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_3").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_4").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_5").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_6").GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 5:
                GameObject.Find("lives_1").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_2").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_3").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_4").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_5").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_6").GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 4:
                GameObject.Find("lives_1").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_2").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_3").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_4").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_5").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_6").GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 3:
                GameObject.Find("lives_1").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_2").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_3").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_4").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_5").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_6").GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 2:
                GameObject.Find("lives_1").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_2").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_3").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_4").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_5").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_6").GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 1:
                GameObject.Find("lives_1").GetComponent<SpriteRenderer>().color = Color.red;
                GameObject.Find("lives_2").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_3").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_4").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_5").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_6").GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 0:
                GameObject.Find("lives_1").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_2").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_3").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_4").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_5").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("lives_6").GetComponent<SpriteRenderer>().color = Color.white;
                if (gameISover == false)
                {
                    Invoke("GameOver", 2f);
                }
                break;
            default:
                break;
        }
    }

    void GameOver()
    {
        if(gameISover == false)
        {
            CancelInvoke();
            gameISover = true;
            GameObject.Find("GameOverCanvas").GetComponent<Canvas>().planeDistance = 100;
            Debug.Log("Game Over!");
        }

    }



    void ShootTarget1()
    {
        Doggeh.GetComponent<Animator>().Play("doggeh_fetch");
        Invoke("ShootTarget2", 0.5f);
    }

    void ShootTarget2()
    {
        //determine power and determine ammount of targets
        if (score < 10)
        {
            targets = 1;
            power = Random.Range(1f, 1.3f);
        }
        if (score >= 10 && score < 20)
        {
            targets = Random.Range(1, 3);
            power = Random.Range(1f, 1.5f);
        }
        if (score >= 20 && score < 30)
        {
            targets = Random.Range(2, 4);
            power = Random.Range(1.3f, 1.8f);
        }
        if (score >= 30 && score < 40)
        {
            targets = Random.Range(2, 5);
            power = Random.Range(1.4f, 2f);
        }
        if (score >= 40)
        {
            targets = Random.Range(3, 6); // range is <inclusive>,<exclusive>
            power = Random.Range(1.6f, 2.5f);
        }

        Targetteller = 0;
        Debug.Log("start");
        ShootTarget3();
    }

    void ShootTarget3()
    {
        Debug.Log(Time.time.ToString() + " : " + Targetteller + "/" + targets);
        //determine angle
        int angle = Random.Range(1, 2);

        GameObject thisTarget = null;
        GameObject thisBirb = null;
        if (targetAout == true)
        {
            if (targetBout == true)
            {
                if (targetCout == true)
                {
                    if (targetDout == true)
                    {
                        thisTarget = Instantiate(targetE, new Vector2(Doggeh.transform.position.x, Doggeh.transform.position.y), this.transform.rotation);
                        thisTarget.name = "target_e";

                        thisBirb = Instantiate(birbPrefab, new Vector2(Doggeh.transform.position.x - 2, Doggeh.transform.position.y), this.transform.rotation);
                        thisBirb.GetComponent<birbScrip>().myTarget = thisTarget.gameObject;
                        thisBirb.name = "birbE";

                        targetEout = true;
                        Debug.Log("Target E launched");
                    }
                    else
                    {
                        thisTarget = Instantiate(targetD, new Vector2(Doggeh.transform.position.x, Doggeh.transform.position.y), this.transform.rotation);
                        thisTarget.name = "target_d";

                        thisBirb = Instantiate(birbPrefab, new Vector2(Doggeh.transform.position.x - 2, Doggeh.transform.position.y), this.transform.rotation);
                        thisBirb.GetComponent<birbScrip>().myTarget = thisTarget.gameObject;
                        thisBirb.name = "birbD";

                        targetDout = true;
                        Debug.Log("Target D launched");
                    }
                }
                else
                {
                    thisTarget = Instantiate(targetC, new Vector2(Doggeh.transform.position.x, Doggeh.transform.position.y), this.transform.rotation);
                    thisTarget.name = "target_c";

                    thisBirb = Instantiate(birbPrefab, new Vector2(Doggeh.transform.position.x - 2, Doggeh.transform.position.y), this.transform.rotation);
                    thisBirb.GetComponent<birbScrip>().myTarget = thisTarget.gameObject;
                    thisBirb.name = "birbC";

                    targetCout = true;
                    Debug.Log("Target C launched");
                }
            }
            else
            {
                thisTarget = Instantiate(targetB, new Vector2(Doggeh.transform.position.x, Doggeh.transform.position.y), this.transform.rotation);
                thisTarget.name = "target_b";

                thisBirb = Instantiate(birbPrefab, new Vector2(Doggeh.transform.position.x - 2, Doggeh.transform.position.y), this.transform.rotation);
                thisBirb.GetComponent<birbScrip>().myTarget = thisTarget.gameObject;
                thisBirb.name = "birbB";

                targetBout = true;
                Debug.Log("Target B launched");
            }
        }
        else
        {
            thisTarget = Instantiate(targetA, new Vector2(Doggeh.transform.position.x, Doggeh.transform.position.y), this.transform.rotation);
            thisTarget.name = "target_a";

            thisBirb = Instantiate(birbPrefab, new Vector2(Doggeh.transform.position.x - 2, Doggeh.transform.position.y), this.transform.rotation);
            thisBirb.GetComponent<birbScrip>().myTarget = thisTarget.gameObject;
            thisBirb.name = "birbA";


            targetAout = true;
            Debug.Log("Target A launched");
        }

        thisTarget.GetComponent<Rigidbody2D>().AddForce(Vector2.up * power, ForceMode2D.Impulse);
        if (angle == 1)
        {
            thisTarget.GetComponent<Rigidbody2D>().AddForce(Vector2.left * (Random.Range(1, 5)), ForceMode2D.Impulse);
        }
        else
        {
            thisTarget.GetComponent<Rigidbody2D>().AddForce(Vector2.right * (Random.Range(1, 5)), ForceMode2D.Impulse);
        }

        Targetteller++;
        if (Targetteller < targets)
        {
            Invoke("ShootTarget3", Random.Range(0.3f,1f));
        }

    }

    public void nextGame()
    {
        caught = 0;
        delay = Random.Range(1, 10);
        Doggeh.GetComponent<Animator>().Play("doggeh_search");
        Invoke("ShootTarget1", delay);
    }


}

