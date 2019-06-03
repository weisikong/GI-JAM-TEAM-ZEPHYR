using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeScript : MonoBehaviour
{
   [SerializeField] Image[] images = new Image[3];
    [SerializeField] Sprite HPon;
    [SerializeField] Sprite HPoff;
    private int health = 5;
    private float prevHitTime;
    private const float waitHitTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Drop health
    public void dropHealth()
    {
        health--;
    }
    //returns the death bool true.
    public bool getDead()
    {
        return health>0;
    }
    // Update is called once per frame
    void Update()
    {

        if (GameManager.characterHit && prevHitTime + waitHitTime < Time.time)
        {
            prevHitTime = Time.time;
            dropHealth();
            GameManager.characterHit = false;
        }
        if (!getDead())
            SceneManager.LoadScene("EndScene", LoadSceneMode.Single);

        for (int i = 0; i <5;i++)
        {
            if(i<health)
            {
                images[i].sprite = HPon;
            }
            else
            {
                images[i].sprite = HPoff;
            }
        }
    }
}
