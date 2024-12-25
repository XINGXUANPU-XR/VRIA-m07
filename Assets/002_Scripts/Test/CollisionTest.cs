using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField]
    Material material;

    [SerializeField]
    Color enterColor,stayColor,exitColor;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollisionEnter 発生[{collision.gameObject.name}]");
        ChangeColor(enterColor);
    }
    void OnCollisionStay(Collision collision)
    {
        Debug.Log($"OnCollisionStay 発生[{collision.gameObject.name}]");
        ChangeColor(stayColor);
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log($"OnCollisionExit 発生[{collision.gameObject.name}]");
        ChangeColor(exitColor);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter 発生[{collision.gameObject.name}]");
        ChangeColor(enterColor);
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay 発生[{collision.gameObject.name}]");
        ChangeColor(stayColor);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit 発生[{collision.gameObject.name}]");
        ChangeColor(exitColor);
    }

    void ChangeColor(Color color)
    {
        //material.color = color;
        GetComponent<Renderer>().material.color = color;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
