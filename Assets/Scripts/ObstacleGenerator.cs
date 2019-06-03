using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject obstacleObject;
    [SerializeField] float timeDelay;
    [SerializeField] float timeDelayRandomFactor;
    [SerializeField] GameObject worldRotater;
    [SerializeField] float xMin, xMax;
    [SerializeField] GameObject character;


    List<GameObject> spawnedObstacles = new List<GameObject>();
    float prevTime;

    void Start() {
        prevTime = Time.time;
    }

    void Update() {
        float randTime = Random.Range(
            timeDelay - timeDelay * timeDelayRandomFactor,
            timeDelay + timeDelay * timeDelayRandomFactor);

        // create new
        if (prevTime + randTime < Time.time) {
            GameObject newObs = Instantiate(
                obstacleObject,
                CreateStartingPosition(),
                CreateStartingRotation(),
                worldRotater.transform);
            spawnedObstacles.Add(newObs);

            prevTime = Time.time;
        }

        // remove existing
        if (
            spawnedObstacles.Count > 0
            &&
            spawnedObstacles[0].transform.position.y
            >
            GameManager.yDestroy
            &&
            spawnedObstacles[0].transform.position.z
            <
            GameManager.zDestroy
        ) {
            Destroy(spawnedObstacles[0]);
            spawnedObstacles.RemoveAt(0);
        }

        checkIfCollided();
    }

    Vector3 CreateStartingPosition() {
        float random = Random.Range(-40, 40);
        return new Vector3(random,
            GameManager.ySpawn,
            GameManager.zSpawn);
       
    }

    Quaternion CreateStartingRotation() {
        return Quaternion.Euler(
            GameManager.xRotationSpawn, 0f, 0f);
    }


    void checkIfCollided() {
        Bounds charCol = character.GetComponent<BoxCollider>().bounds;
        for (int i = 0; i < spawnedObstacles.Count; ++i)
        {
            Bounds obsCol = spawnedObstacles[i].GetComponent<CapsuleCollider>().bounds;
            if (charCol.Intersects(obsCol))
            {
                GameManager.characterHit = true;
            }
        }
    }
}
