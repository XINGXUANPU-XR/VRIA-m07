using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ransport : MonoBehaviour
{
    //�ڕW�`���ʒu
    public Vector3 teleportPosition;

    //�ڐG����
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
