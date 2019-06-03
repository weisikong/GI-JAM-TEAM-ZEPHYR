using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotater : MonoBehaviour
{
    void Update() {
        transform.Rotate(GameManager.worldSpeed * Time.deltaTime, 0f, 0f,
            Space.Self);
    }
}
