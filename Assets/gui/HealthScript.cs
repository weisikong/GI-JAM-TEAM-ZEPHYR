using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    [SerializeField] Image[] images = new Image[3];
    [SerializeField] Sprite HPon;
    [SerializeField] Sprite HPoff;
    private int health = 3;
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
        return (health>0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dropHealth();
        }
        for(int i = 0; i <3;i++)
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
