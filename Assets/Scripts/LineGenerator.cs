using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    [SerializeField] GameObject lineObject;
    [SerializeField] GameObject worldRotater;
    [SerializeField] float timeDelay;

    bool lineCreated = false;

    List<GameObject> spawnedLines = new List<GameObject>();
    float prevTime;
            
    // Start is called before the first frame update
    void Start()
    {
        prevTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(prevTime + timeDelay < Time.time)
        {
            GameObject newObs = Instantiate(
                lineObject,
                CreateStartingPosition(),
                CreateStartingRotation(),
                worldRotater.transform);
            spawnedLines.Add(newObs);

            prevTime = Time.time;
        }

        if(spawnedLines.Count > 0
            &&
            spawnedLines[0].transform.position.y
            >
            GameManager.yDestroy
            &&
            spawnedLines[0].transform.position.z
            <
            GameManager.zDestroy)
        {
            Destroy(spawnedLines[0]);
            spawnedLines.RemoveAt(0);
        }
    }

    Vector3 CreateStartingPosition()
    {
        return new Vector3(0,
            GameManager.ySpawn +0.6f,
            GameManager.zSpawn);
    }

    Quaternion CreateStartingRotation()
    {
        return Quaternion.Euler(GameManager.xRotationSpawn, 0f, 0f);
    }
}
