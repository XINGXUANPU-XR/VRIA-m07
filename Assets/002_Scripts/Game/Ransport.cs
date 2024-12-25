using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ransport : MonoBehaviour
{
    //–Ú•W“`‘—ˆÊ’u
    public Vector3 teleportPosition;

    //ÚG–Œ
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) ;
        {
            other.transform.position = teleportPosition;
        }
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
