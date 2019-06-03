using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] obstacleObjects;
    [SerializeField] float randMinScale;
    [SerializeField] float randMaxScale;
    [SerializeField] float timeDelay;
    [SerializeField] float timeDelayRandomFactor;
    [SerializeField] GameObject worldRotater;
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
                obstacleObjects[Random.Range(0, obstacleObjects.Length - 1)],
                CreateStartingPosition(),
                CreateStartingRotation(),
                worldRotater.transform);
            newObs.transform.localScale = CreateStartingScale();
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

        // colliding into obstacle
        checkIfCollided();
    }

    Vector3 CreateStartingPosition() {
        return new Vector3(Random.Range(-36f, 36f),
            GameManager.ySpawn,
            GameManager.zSpawn);
    }

    Quaternion CreateStartingRotation() {
        return Quaternion.Euler(
            GameManager.xRotationSpawn, 0f, 0f);
    }

    Vector3 CreateStartingScale()
    {
        return new Vector3(
            Random.Range(randMinScale, randMaxScale),
            Random.Range(randMinScale, randMaxScale),
            Random.Range(randMinScale, randMaxScale));
    }

    void checkIfCollided() {
        Bounds charCol = character.GetComponent<BoxCollider>().bounds;
        for (int i = 0; i < spawnedObstacles.Count; ++i) {
            Bounds obsCol = spawnedObstacles[i].GetComponent<BoxCollider>().bounds;
            if (charCol.Intersects(obsCol))
            {
                GameManager.characterHit = true;
            }
        }
    }
}
