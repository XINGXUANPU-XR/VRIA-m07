using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparisonOperator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 5;
        int y = 8;

        Debug.Log(x == y);
        Debug.Log(x != y);
        Debug.Log(x > y);
        Debug.Log(x < y);
        Debug.Log(x >= y);
        Debug.Log(x <= y);
        Debug.Log(x > 5);
        Debug.Log(x <= 5);

        if(x == y)
        {
            Debug.Log("x��y�͓������ł�.");
        }
        if(x != y)
        {
            Debug.Log("x��y�͓������Ȃ��ł�.");
        }

        bool trueOrFalse = (x == y);    //5 == 8 False

        if(trueOrFalse)     //�����AtrueOrFalse���^(true)�Ȃ�
        {
            Debug.Log("x��y�͓������ł�.");    //Flase�̂��ߕ\������Ȃ�
        }

        trueOrFalse = (x != y); //5 != 8 True

        if(trueOrFalse) 
        {
            Debug.Log("x��y�͓������ł�.");    //True�̂��ߕ\�������
        }

        int age = 20;
        string message;

        //����? True�ꍇ�̒l : false�̏ꍇ�̒l
        message = (age<20) ?   "Too Young" : ((age<65) ? "Old Enough" : "Too Old");
        //if        (age<20)    message = "Too Young";
        //else if   (age < 65)  message = "Old Enough";
        //else                  message = "Too Old";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
