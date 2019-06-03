using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurbGenerator : MonoBehaviour
{
    [SerializeField] GameObject curbObject;
    [SerializeField] GameObject worldRotater;

    bool curbCreated = false;
    List<GameObject> movingPiecesLeft = new List<GameObject>();
    List<GameObject> movingPiecesRight = new List<GameObject>();

    void Start() {
        GameObject newCurbLeft = Instantiate(
            curbObject,
            CreateStartingPositionLeft(),
            CreateStartingRotation(),
            worldRotater.transform);

        newCurbLeft.transform.GetChild(0).GetComponent<MeshRenderer>().shadowCastingMode =
            UnityEngine.Rendering.ShadowCastingMode.Off;

        movingPiecesLeft.Add(newCurbLeft);


        GameObject newCurbRight = Instantiate(
            curbObject,
            CreateStartingPositionRight(),
            CreateStartingRotation(),
            worldRotater.transform);

        newCurbRight.transform.GetChild(0).GetComponent<MeshRenderer>().shadowCastingMode =
            UnityEngine.Rendering.ShadowCastingMode.Off;

        movingPiecesRight.Add(newCurbRight);
    }

    void Update() {
        if (!curbCreated) {
            curbCreated = true;

            GameObject newCurbLeft = Instantiate(
                curbObject,
                CreateStartingPositionLeft(),
                CreateStartingRotation(),
                transform);

            newCurbLeft.transform.GetChild(0).GetComponent<MeshRenderer>().shadowCastingMode =
                UnityEngine.Rendering.ShadowCastingMode.Off;

            movingPiecesLeft.Add(newCurbLeft);


            GameObject newCurbRight = Instantiate(
               curbObject,
               CreateStartingPositionRight(),
               CreateStartingRotation(),
               transform);

            newCurbRight.transform.GetChild(0).GetComponent<MeshRenderer>().shadowCastingMode =
                UnityEngine.Rendering.ShadowCastingMode.Off;

            movingPiecesRight.Add(newCurbRight);
        }
        else {
            Bounds staticCurbColLeft = movingPiecesLeft[movingPiecesLeft.Count - 1]
                .GetComponent<Collider>().bounds;
            Bounds lastMovingCurbColLeft = movingPiecesLeft[movingPiecesLeft.Count - 2]
                .GetComponent<Collider>().bounds;

            if (!staticCurbColLeft.Intersects(lastMovingCurbColLeft)) {
                curbCreated = false;
                movingPiecesLeft[movingPiecesLeft.Count - 1].transform.parent =
                    worldRotater.transform;
            }


            Bounds staticCurbColRight = movingPiecesLeft[movingPiecesRight.Count - 1]
                .GetComponent<Collider>().bounds;
            Bounds lastMovingCurbColRight = movingPiecesLeft[movingPiecesRight.Count - 2]
                .GetComponent<Collider>().bounds;

            if (!staticCurbColRight.Intersects(lastMovingCurbColRight))
            {
                curbCreated = false;
                movingPiecesRight[movingPiecesRight.Count - 1].transform.parent =
                    worldRotater.transform;
            }
        }
    }

    Vector3 CreateStartingPositionLeft() {
        return new Vector3(
            GameManager.roadSize / 2 * -1,
            GameManager.ySpawn,
            GameManager.zSpawn);
    }

    Vector3 CreateStartingPositionRight() {
        return new Vector3(
            GameManager.roadSize / 2,
            GameManager.ySpawn,
            GameManager.zSpawn);
    }

    Quaternion CreateStartingRotation() {
        return Quaternion.Euler(
            GameManager.xRotationSpawn, 0f, 0f);
    }
}
