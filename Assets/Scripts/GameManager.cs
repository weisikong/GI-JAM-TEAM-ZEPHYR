using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float worldSpeed = 20f;

    public static float xCreationMin = -685f;
    public static float xCreationMax = 685f;
    public static float ySpawn = 192.53f;
    public static float yDestroy = -192.53f;
    public static float zSpawn = -51.31f;
    public static float zDestroy = -53.31f;
    public static float xRotationSpawn = 164.9f;

    public static float roadSize = 80f;

    public static bool characterHit = false;
}
