using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirtheticTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(1 + 2);
        Debug.Log(30 - 29);
        Debug.Log(9 * 9);
        Debug.Log(120 / 5);
        Debug.Log(120 / 7);
        Debug.Log(120 % 7);

        int sum = 5 + 13;
        Debug.Log(sum);

        //sum = sum + 1;
        sum += 1;
        Debug.Log(sum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
