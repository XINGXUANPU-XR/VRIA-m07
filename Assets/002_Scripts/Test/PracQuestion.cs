using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;


public class PracQuestion : MonoBehaviour
{
    //[SerializeField]
    //public int age;

    //[SerializeField]
    //public int birth;

    //[SerializeField]
    //float gatchaRate;

    //[SerializeField]
    //string targetName;

    [SerializeField]
    public int examPoint;

    //private bool isCtrlPressed;


    // Start is called before the first frame update
    void Start()
    {
        //Q1
        //int x = 0;
        //Debug.Log(x);

        //Q2
        //int num001;
        //int num002;
        //int t;

        //num001 = 1;
        //num002 = 2;

        //Debug.Log(num001);
        //Debug.Log(num002);

        //t = num001;
        //num001 = num002;
        //num002 = t;

        //Debug.Log(num001);
        //Debug.Log(num002);

        //Q3
        //Debug.Log(Math.Pow(2, 3));
        //Debug.Log(Math.Pow(4, 5));
        //Debug.Log(Math.Pow(6, 9));
        //Debug.Log(Math.Sqrt(24));
        //Debug.Log(Math.Sqrt(144));
        //Debug.Log(Math.Sqrt(200));

        //Q4
        //Debug.Log(2024-26);

        //Q5
        //Debug.Log(birth + age);

        //Q6
        //string s0 = "I";
        //string s1 = "Love";
        //string s2 = "You";
        //Debug.Log(s0 + " " + s1 + " " + s2);   

        //Q7
        //Debug.Log("\b");
        //Debug.Log("\'");
        //Debug.Log("@");
        //Debug.Log("\"");

        //Q8
        //Debug.Log(transform.position);

        //Q9
        //transform.position = new Vector3(0.0f,0.0f,1.0f);
        //Debug.Log(transform.position);
        //transform.position = new Vector3(-1.0f, 0.0f, 0.0f);
        //Debug.Log(transform.position);
        //transform.position = new Vector3(0.0f,3.0f,1.0f);
        //Debug.Log(transform.position);

        //Q10
        //AnniversaryGatcha(gatchaRate);

        //Q11
        //if (targetName == "父") Debug.Log("スパイ");
        //if (targetName == "母") Debug.Log("掃除屋");
        //if (targetName == "娘") Debug.Log("エスパー");

        //Q15
        //if(examPoint>=0)
        //{ 
        //    if (examPoint >= 60) Debug.Log("合格");
        //    else Debug.Log("不合格");
        //}
        //else
        //{
        //    Debug.Log("エラー");
        //}

        //Q16
        //for (int i = -50; i <= 50; i++)
        //{
        //    Debug.Log(i);
        //}

        //Q17
        //for(int i = 10;i>=0;i--)
        //{
        //    Debug.Log(i);
        //}

        //Q18
        //for(int i=50;i<=150;i++)
        //{
        //    if(i%7==0) Debug.Log(i);
        //
        //}

        //Q19
        //for(int i=20;i<=40;i++)
        //{
        //    if(i%2!=0) Debug.Log(i);
        //}

        //Q20
        for(int i=2;i<=10;i++)
        {
            int a = 1;
            int count = 0;
            if(i%(i-1)==0) Debug.Log(i);
        }
    }

    void AnniversaryGatcha(float gatchaRate)
    {
        if (gatchaRate == 0.5f)
        {
            Debug.Log("SSRです");
        }
        if (gatchaRate == 5.0f)
        {
            Debug.Log("SRです");
        }
        if (gatchaRate == 16.5f)
        {
            Debug.Log("Rです");
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Q12
        //if (Keyboard.current.fKey.wasPressedThisFrame) Debug.Log("Fキーが押されました");
        //Q13
        //if (Keyboard.current.rightArrowKey.isPressed) Debug.Log("->キーが押されました");
        //Q14
        //if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        //{
        //    isCtrlPressed = true;
        //}

        // Ctrlキーが離されたとき
        //if (isCtrlPressed && (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl)))
        //{
        //    isCtrlPressed = false;
        //    Debug.Log("Ctrl キーが押され終わりました");
        //}

       


    }

}
