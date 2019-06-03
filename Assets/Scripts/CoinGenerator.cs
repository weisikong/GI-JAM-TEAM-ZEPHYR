using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] GameObject coinObject;
    [SerializeField] GameObject worldRotater;
    [SerializeField] GameObject character;
    [SerializeField] CoinCounter coinz;

    List<GameObject> spawnedcoins = new List<GameObject>();
    float prevTime;

    void Start()
    {
        prevTime = Time.time;
    }

    void Update()
    {
        // create new
        if (Time.time - prevTime > Random.Range(1, 15))
        {
            GameObject newObs = Instantiate(
                coinObject,
                CreateStartingPosition(),
                CreateStartingRotation(),
                worldRotater.transform);
            spawnedcoins.Add(newObs);

            prevTime = Time.time;
        }

        // remove existing
        if (
            spawnedcoins.Count > 0
            &&
            spawnedcoins[0].transform.position.y
            >
            GameManager.yDestroy
            &&
            spawnedcoins[0].transform.position.z
            <
            GameManager.zDestroy
        )
        {
            Destroy(spawnedcoins[0]);
            spawnedcoins.RemoveAt(0);
        }

        checkIfCollided();
    }

    Vector3 CreateStartingPosition()
    {
        return new Vector3(Random.Range(-20f, 20f),
            Random.Range(GameManager.ySpawn - 8, GameManager.ySpawn - 13),
            GameManager.zSpawn);
    }

    Quaternion CreateStartingRotation()
    {
        return Quaternion.Euler(
            GameManager.xRotationSpawn, 0f, 0f);
    }

    void checkIfCollided() {
        Bounds charCol = character.GetComponent<BoxCollider>().bounds;
        for (int i = 0; i < spawnedcoins.Count; ++i)
        {
            Bounds obsCol = spawnedcoins[i].GetComponent<SphereCollider>().bounds;
            if (charCol.Intersects(obsCol))
            {
                coinz.addCoin();
            }
        }
    }
}
