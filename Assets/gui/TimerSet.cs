using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSet : MonoBehaviour
{
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int integerTime = (int)Time.fixedTime;
        int integerMinute = integerTime/60,
        integerSecond = integerTime%60;
        text.text = "T:"+integerMinute+":"+integerSecond;
    }
}
