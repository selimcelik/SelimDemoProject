using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{
    public GameObject[] downObjects;
    public Transform[] whereToSpawnObjects;

    public GameObject greenSwip;
    public GameObject blueSwip;

    float nextSpawn = 0.0f;
    public float spawnRate = 0.75f;


    void Start()
    {
       StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(downObjects[Random.Range(0, downObjects.Length)], whereToSpawnObjects[Random.Range(0,whereToSpawnObjects.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (greenSwiperControl.greenswipCreator)
        {
            Instantiate(greenSwip, new Vector3(0, 0.04f, -1.018f), Quaternion.identity);
        }

        if (blueSwiperControl.blueswipCreator)
        {
            Instantiate(blueSwip, new Vector3(0, -0.73f, -1.018f), Quaternion.identity);
        }

    }
}
