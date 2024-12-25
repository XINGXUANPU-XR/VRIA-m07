using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTest : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI timerText;

    [SerializeField]
    TextMeshProUGUI deltaTimerText;

    [SerializeField]
    TextMeshProUGUI netDeltaTimerText;

    [SerializeField]
    TextMeshProUGUI fixedTimerText;

    [SerializeField]
    TextMeshProUGUI fixedDeltaTimerText;


    [SerializeField]
    float threshold = 3.0f;

    [SerializeField]
    bool stopTime = true;

    float timer = 0.0f;

    float netDeltaTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);

        timerText.text = $"Time.time:{Time.time}";

        //if( 3 <= Time.time)
        //{
        //    Debug.Log("�R�b�o��");
        //}


        //if(timer <= Time.time)
        //{
        //    Debug.Log($"{threshold}�b�o��");
        //
        //    timer += threshold;
        //}

        //Debug.Log(Time.deltaTime);

        deltaTimerText.text = $"Time.deltaTime : {Time.deltaTime}";

        netDeltaTime += Time.deltaTime;
        netDeltaTimerText.text = $"Net deltaTime: {netDeltaTime}";

        if (timer <= netDeltaTime)
        {
            Debug.Log($"{threshold}�b�o��");
        
            timer += threshold;
        }

        StopTime();

    }

    void FixedUpdate()
    {
        Debug.Log(Time.fixedTime);
        Debug.Log(Time.fixedDeltaTime);

        fixedTimerText.text = $"Time.fixedtime:{Time.fixedTime}";
        fixedDeltaTimerText.text = $"Time.fixeddeltaTime : {Time.fixedDeltaTime}";
    }

    void StopTime()
    {
        if(stopTime) 
        {
            Time.timeScale = 0.0f;
            Debug.Log("timeScale = 0.0f: ���Ԓ�~��");
        }
        else
        {
            //Time.timeScale = 1.0f;
            //Debug.Log("time.Scale =1.0f: ���Ԃ𓮂��Ă�");
            Time.timeScale = 2.0f;
            Debug.Log("time.Scale =1.0f: ���Ԃ�2�{�ł𓮂��Ă�");
        }
    }
}
