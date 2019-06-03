using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampGenerator : MonoBehaviour
{
    [SerializeField] GameObject lampObject;
    [SerializeField] float timeDelay;
    [SerializeField] GameObject worldRotater;
    [SerializeField] float xMin, xMax;


    List<GameObject> spawnedLeftLamp = new List<GameObject>();
    List<GameObject> spawnedRightLamp = new List<GameObject>();
    float prevTime;

    void Start()
    {
        prevTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(prevTime + timeDelay < Time.time)
        {
            GameObject newLeftObs = Instantiate(
                lampObject,
                CreateLeftStartingPosition(),
                CreateStartingRotation(),
                worldRotater.transform);
            spawnedLeftLamp.Add(newLeftObs);

            GameObject newRightObs = Instantiate(
                lampObject,
                CreateRightStartingPosition(),
                CreateStartingRotation(),
                worldRotater.transform);
            spawnedRightLamp.Add(newRightObs);

            prevTime = Time.time;
        } 
        if(spawnedLeftLamp.Count > 0 
            &&
            spawnedLeftLamp[0].transform.position.y > 
            GameManager.yDestroy && 
            spawnedLeftLamp[0].transform.position.z <
            GameManager.zDestroy)
        {
            Destroy(spawnedLeftLamp[0]);
            spawnedLeftLamp.RemoveAt(0);
        }
        if (spawnedRightLamp.Count > 0
           &&
           spawnedRightLamp[0].transform.position.y >
           GameManager.yDestroy &&
           spawnedRightLamp[0].transform.position.z <
           GameManager.zDestroy)
        {
            Destroy(spawnedRightLamp[0]);
            spawnedRightLamp.RemoveAt(0);
        }
    }

    Vector3 CreateLeftStartingPosition()
    {
        return new Vector3(-43,
            GameManager.ySpawn,
            GameManager.zSpawn);
    }
    Vector3 CreateRightStartingPosition()
    {
        return new Vector3(43,
            GameManager.ySpawn,
            GameManager.zSpawn);
    }


    Quaternion CreateStartingRotation()
    {
        return Quaternion.Euler(
            GameManager.xRotationSpawn, 0f, 0f);
    }
}
