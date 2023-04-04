using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    GameObject lastPlatform;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject diamondPrefab;
    [SerializeField] BallController ballController;

    int platformCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastPlatform = Instantiate(platformPrefab, new Vector3(4, 0, 6), Quaternion.Euler(0, 0, 0));

        for (platformCount = 0; platformCount < 20;  platformCount++)
        {
            StartCoroutine(SpawnNewPlatform(0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballController.CheckIsFalling())
        {
            StartCoroutine(SpawnNewPlatform(0.2f));
        }
    }

    IEnumerator SpawnNewPlatform(float delay)
    {
        int spawnOnZAxis = UnityEngine.Random.Range(0,2);
        int spawnDiamond = UnityEngine.Random.Range(0,2);

        switch (spawnOnZAxis)
        {
            case 0:
                {
                    lastPlatform = Instantiate(platformPrefab, lastPlatform.transform.position + new Vector3(2f, 0f, 0f), Quaternion.Euler(0, 0, 0));
                    break;
                }
            case 1:
                {
                    lastPlatform = Instantiate(platformPrefab, lastPlatform.transform.position + new Vector3(0f, 0f, 2f), Quaternion.Euler(0, 0, 0));
                    break;
                }
        }


        GameObject diamond = null;
        if (spawnDiamond == 1)
        {
            diamond = Instantiate(diamondPrefab, lastPlatform.transform.position + new Vector3(0f, 1.6f, 0f), Quaternion.Euler(0, 0, 0));
        }

        yield return new WaitForSeconds(delay);
    }
}
