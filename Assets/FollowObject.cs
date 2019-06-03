using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform obstacle;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = obstacle.position + offset;
    }
}