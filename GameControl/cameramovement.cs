using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class cameramovement : MonoBehaviour
{
    [Header("Bars")]
    [SerializeField] GameObject[] Bars = new GameObject[4];
    [SerializeField] GameObject changeBricks;
    [SerializeField] Transform[] changeTransform = new Transform[2];

    public float SpawnTime = 5;
    public GameObject[] spawnpositions = new GameObject[2];

    [Header("WallFie")]
    public GameObject wallFire;
    public GameObject[] spawnpoints = new GameObject[2];

    [Header("SpaceMallow")]
    public GameObject spaceMallow;

    [Header("Hearth")]
    public GameObject hearth;

    public static int coin;
    public float cameraspeed;
    bool pointcountActive = true;
   public static float pointamount;
    float pointpersecond;
    public Text pointtext;
    public Text highestScore;
    public static bool isdead;
    public GameObject _panel;
    public Text score;
    public Text coinke;
    AudioSource mainmusic;


    private void Awake()
    {

        _panel.SetActive(false);
        Time.timeScale = 1;
        cameraspeed = 1;
        isdead = false;
        highestScore.text = "Highest" + " " + ((int)PlayerPrefs.GetFloat("HF")).ToString();
        SpawnTime = 5;
        pointamount = 0;
        pointpersecond = 1f;
    }
    private void Start()
    {
        mainmusic = GetComponent<AudioSource>();
        //Time.timeScale = 1;
        //cameraspeed = 1;
        //isdead = false;
        //highestScore.text = "Highest" + " " + ((int)PlayerPrefs.GetFloat("HF")).ToString();
        //SpawnTime = 4;
        //pointamount = 0;
        //pointpersecond = 1f;
        StartCoroutine(increasing());
        StartCoroutine(IsDeath());
        StartCoroutine(WallFire());
        StartCoroutine(SpawnMallow());
        StartCoroutine(SpawnBars());
        StartCoroutine(hearthreviev());
        StartCoroutine(changebrick());
        coinke.text = (PlayerPrefs.GetInt("Coin")).ToString();

        mainmusic.Play();

    }


    IEnumerator IsDeath()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (isdead)
            {
                Advertisement._advs.showInters();
                if (PlayerPrefs.GetFloat("HF") < pointamount)
                {
                    PlayerPrefs.SetFloat("HF", pointamount);
                }

                cameraspeed = 0;
                pointpersecond = 0;

                _panel.SetActive(true);
                score.text = ((int)pointamount).ToString();
                //coin += (int)pointamount;
                //PlayerPrefs.SetInt("Coin", coin);
                //SceneManager.LoadScene(2);
                cameraspeed = 0;
                StopAllCoroutines();

                break;
            }


        }
    }

    IEnumerator SpawnMallow()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);

            Instantiate(spaceMallow, spawnpositions[1].transform.position, spawnpositions[1].transform.rotation);
            yield return new WaitForSeconds(10f);
        }
    }

    IEnumerator hearthreviev()
    {
        while (true)
        {
            int rnd = Random.Range(0, 2);
            yield return new WaitForSeconds(15f);
            Instantiate(hearth, spawnpoints[rnd].transform.position, spawnpoints[rnd].transform.rotation);
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator SpawnBars()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            Spawn();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("saw"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bars") || collision.gameObject.CompareTag("WallFlame"))
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("pl"))
        {
            isdead = true;
        }

    }
    IEnumerator changebrick()
    {
        while (true)
        {
            int rnd = Random.Range(0, 2);
            yield return new WaitForSeconds(10f);
            Instantiate(changeBricks, changeTransform[rnd].transform.position, changeBricks.transform.rotation);
        }
    }

    IEnumerator WallFire()
    {
        while (true)
        {
            int rnd = Random.Range(0, 2);
            yield return new WaitForSeconds(15f);
            Instantiate(wallFire, spawnpoints[rnd].transform.position, spawnpoints[rnd].transform.rotation);
            yield return new WaitForSeconds(15f);
        }
    }
    void Spawn()
    {
        int rnd = Random.Range(0, 4);
        int sidernd = Random.Range(0, 3);




        Instantiate(Bars[rnd], spawnpositions[sidernd].transform.position, spawnpositions[sidernd].transform.rotation);


        //float[] arrayX = new float[2] { maxX, minX };
        //int RandomX = Random.Range(0, 1);

        //float RandomY = Random.Range(minY, maxY);

        //Instantiate(Bars, transform.position  + new Vector3(arrayX[RandomX], RandomY, 0), transform.rotation);
    }
    void Update()
    {
        if (pointcountActive)
        {
            pointtext.text = ((int)pointamount).ToString();
            pointamount += pointpersecond * Time.deltaTime;

        }


        transform.position += new Vector3(0, cameraspeed * Time.deltaTime, 0);

        //if (cont2d.Death)
        //{
        //    if (PlayerPrefs.GetFloat("HF") < pointamount)
        //    {
        //        PlayerPrefs.SetFloat("HF", pointamount);
        //    }

        //    cameraspeed = 0;
        //    pointpersecond = 0;
        //    SpawnObject.SpawnTime = 1000;


        //    endgamescore.text = "Your Score" + " " + pointtext.text;
        //    pointtext.gameObject.SetActive(false);
        //    endingGameMenu.SetActive(true);
        //}

    }
    //public static void Again()
    //{


    //    SceneManager.LoadScene(1);

    //    SpawnObject.SpawnTime = 3;
    //    cont2d.Death = false;
    //}
    IEnumerator increasing()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);


            if (cameraspeed >= 5f)
            {
                //StopCoroutine(increasing());
                SpawnTime = 1f;
                BackgroundScroller.divided = 5f;
                pointpersecond = 20f;

                break;

            }
            pointpersecond += .5f;
            cameraspeed += .20f;
            BackgroundScroller.divided -= .20f;
            SpawnTime -= 0.20f;
            yield return new WaitForSeconds(2f);

        }
    }
    public void Again()
    {
        coin += (int)pointamount;
        PlayerPrefs.SetInt("Coin", coin);
       
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
    public void quitGame()
    {
        coin += (int)pointamount;
        PlayerPrefs.SetInt("Coin", coin);
        
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}

