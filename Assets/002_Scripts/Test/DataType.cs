using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class DataType : MonoBehaviour
{
    //”’lŒ^
    int integerNumber;
    float floatNumber;
    double doubleNumber;
    //•¶š—ñŒ^
    char charater;
    string stringData;



    // Start is called before the first frame update
    void Start()
    {
        integerNumber = 8;
        Debug.Log(integerNumber);

        floatNumber = 1.5f;
        Debug.Log(floatNumber);

        doubleNumber = 1.23456789;
        Debug.Log(doubleNumber);

        charater = 'a';
        Debug.Log(charater);

        stringData = "unity";
        Debug.Log(stringData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
