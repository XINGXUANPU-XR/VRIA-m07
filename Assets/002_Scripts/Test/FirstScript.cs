using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{


    int number;//int(êÆêî)å^ÇÃïœêî
    int smallNumber;


    void HelloUnity()
    {
        Debug.Log("Hello Unity!");
        Debug.Log("This is my first method");

    }

    void CalculateAge()
    {
        int birthYear;
        int currentTear;
        int age;

        birthYear = 1995;
        currentTear = 2024;
        age = currentTear - birthYear;

        Debug.Log("My age is " + age);
    }
    void CalculateAge_WithPass(int birthYear, int currentTear)
    {
        int age;

        age= currentTear - birthYear;

        Debug.Log($"My age is {age}");
    }

    int CalculateAge_WP_Return(int birthYear, int currentTear)
    {
        int age;

        age = currentTear - birthYear;

        return age;

    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello Unity!");


        /*number = 151;
         Debug.Log(number);

         smallNumber = 1;
         Debug.Log(smallNumber);

         smallNumber = number;
         Debug.Log(smallNumber);

         Debug.Log(Math.Sqrt(2));//2ÇÃïΩï˚ç™
         Debug.Log(Math.Sqrt(3));
         Debug.Log(Math.Sqrt(7));
         Debug.Log(Math.Sqrt(15));

         Debug.Log(Math.Pow(3, 2));//3ÇÃ2èÊ
         Debug.Log(Math.Pow(3, 3));
         Debug.Log(Math.Pow(3, 7));
         Debug.Log(Math.Pow(3, 15));

         HelloUnity();
        
        CalculateAge();
        CalculateAge_WithPass(1995, 2024);

        int result;
        result = CalculateAge_WP_Return(2000,2024);
        Debug.Log("My age is " + result+ "!");
        */
        int result = CalculateAge_WP_Return(2000, 2024);
        Debug.Log(result);

        Debug.Log(CalculateAge_WP_Return(2000, 2024));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
