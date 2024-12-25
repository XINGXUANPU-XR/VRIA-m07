using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringConcatenation : MonoBehaviour
{

    string name = "John";
    int age = 20;
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("My name is " + name + "." + "I'm " + age + "years old.");
        Debug.Log($"My name is{name}.I'm {age} years old.");

        //Debug.Log("My name is Jhon." + "I'm 20 years old");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
