using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObject : MonoBehaviour
{
    [Header("Bars")]
    [SerializeField] GameObject[] Bars = new GameObject[6];
    
    public  float SpawnTime = 5;
    public GameObject[] spawnpositions = new GameObject[2];

    [Header("WallFie")]
    public GameObject wallFire;
    public GameObject[] spawnpoints = new GameObject[2];

    [Header("SpaceMallow")]
    public GameObject spaceMallow;

    [Header("Hearth")]
    public GameObject hearth;




    private void Start()
    {
        SpawnTime = 5;
        StartCoroutine(WallFire());
        StartCoroutine(SpawnMallow());
        StartCoroutine(SpawnBars());
        StartCoroutine(hearthreviev());
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bars") || collision.gameObject.CompareTag("saw"))
        {
            Destroy(collision.gameObject,2f);
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
        int rnd = Random.Range(0, 6);
        int sidernd = Random.Range(0, 3);

        


          Instantiate(Bars[rnd], spawnpositions[sidernd].transform.position, spawnpositions[sidernd].transform.rotation);
         

        //float[] arrayX = new float[2] { maxX, minX };
        //int RandomX = Random.Range(0, 1);

        //float RandomY = Random.Range(minY, maxY);

        //Instantiate(Bars, transform.position  + new Vector3(arrayX[RandomX], RandomY, 0), transform.rotation);
    }
}
