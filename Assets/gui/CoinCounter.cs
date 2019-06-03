using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    private int coinCount =0;
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void addCoin()
    {
        coinCount++;
    }
    // Update is called once per frame
    void Update()
    {
        text.text = ""+coinCount;
    }
}
