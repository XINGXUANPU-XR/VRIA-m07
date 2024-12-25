using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{

    IEnumerator CoroutineTest_Message()
    {
        Debug.Log("1st Message");
        yield return null;
        Debug.Log("2nd Message");
        yield break;
    }

    IEnumerator CoroutineWaitTest()
    {
        Debug.Log("3秒待ちます");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("3秒経過した");
        yield break;
        Debug.Log("このメッセージは表示されてません");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("CoroutineWaitTest");

        StartCoroutine(CoroutineWaitTest());

        IEnumerator coroutine = CoroutineWaitTest();

        StartCoroutine(coroutine);
    }
}
