using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour
{

    [SerializeField] bool xMovement;
    [SerializeField] bool yMovement;
    [SerializeField] float xMin, xMax, yMin, yMax;

        
    public float speedX = 50.0f;
    public float speedY = 2.0f;
    public float delta = 10f;

    private float prevSwitchTime;
    private const float switchTimeWait = 0.5f;

    //void Update()
    //{
    //    if (xMovement)
    //        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 40), transform.position.y, transform.position.z);
    //    if (yMovement)
    //        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed,10) , transform.position.z);
    //    //if (zMovement)
    //        //transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, 50));
    //    if (xMovement && yMovement)
    //        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 40), Mathf.PingPong(Time.time * speed, 10), transform.position.z);
    //    //if (xMovement && zMovement)
    //    //    transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 50), transform.position.y, Mathf.PingPong(Time.time * speed, 50));
    //    //if (yMovement && zMovement)
    //        //transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 50) , Mathf.PingPong(Time.time * speed, 50));
    //    //if (xMovement && zMovement && yMovement)
    //    //{
    //    //    transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 50), Mathf.PingPong(Time.time * speed, 50), Mathf.PingPong(Time.time * speed, 50));
    //    //    transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 50), Mathf.PingPong(Time.time * speed, 50), Mathf.PingPong(Time.time * speed, 50));
    //    //}

    //}

    private void Start()
    {
        prevSwitchTime = Time.time;
    }

    private void Update() {
        if (xMovement)
        {
            transform.position = new Vector3(
                transform.position.x + speedX * Time.deltaTime,
                transform.position.y,
                transform.position.z);

            if (transform.position.x >= 35 || transform.position.x <= -35)
            {
                if (prevSwitchTime + switchTimeWait < Time.time)
                {
                    speedX *= -1;
                    prevSwitchTime = Time.time;
                }
            }
        }
        if (yMovement)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * speedY + 10), transform.position.z);

            if (transform.position.y > 10.0f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            else if (transform.position.y < -10.0f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        
        //transform.position = new Vector3(transform.position.x, transform.position.y + speedY * Time.deltaTime, transform.position.z);
        //if(transform.position.y >= 100 || transform.position.y <= 10)
        //{
        //    speedY *= -1;
        //}
    }
    }


}
