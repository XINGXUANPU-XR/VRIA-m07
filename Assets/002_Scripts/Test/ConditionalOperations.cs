using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalOperations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IfStatement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IfStatement()
    {

        bool conditionTrue = true;
        bool conditionFalse = false;

        //ifステートメント
        //if(条件)：条件がtureの時、次の処理を行う
        if (conditionTrue)
        {
            Debug.Log("trueのためご処理が呼び出されます");
        }
        if (conditionFalse)
        {
            Debug.Log("falseのためご処理が呼び出されません");
        }

    }
}
