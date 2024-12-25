using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class RigidbodyTest : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 1.0f; //移動速度

    [SerializeField]
    float rotationSpeed = 90.0f;  //回転速度

    [SerializeField]
    bool relativeToWorld;   //ワールド空間の座標か、ローカル空間の座標が切り替えるフラグ

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        RigidbodyMovementTest();
        RigidbodyRotateTest();
    }
    void RigidbodyMovementTest()
    {
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            if (relativeToWorld)
            {
                rb.MovePosition(transform.position + Vector3.forward * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime);
            }
        }
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            if (relativeToWorld)
            {
                rb.MovePosition(transform.position + Vector3.right * (-1) * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(transform.position + transform.right * (-1) * Time.fixedDeltaTime);
            }
        }
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            if (relativeToWorld)
            {
                rb.MovePosition(transform.position + Vector3.forward * (-1) * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(transform.position + transform.forward * (-1) * Time.fixedDeltaTime);
            }
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            if (relativeToWorld)
            {
                rb.MovePosition(transform.position + Vector3.right * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime);
            }
        }
    }

    void RigidbodyRotateTest()
    {
        Quaternion rotationAngle;

        if (Keyboard.current.eKey.isPressed)
        {
            rotationAngle = Quaternion.Euler(Vector3.up * rotationSpeed * Time.fixedDeltaTime);

            rb.MoveRotation(rb.rotation * rotationAngle);
        }
        if (Keyboard.current.qKey.isPressed)
        {
            rotationAngle = Quaternion.Euler(Vector3.up * (-1) * rotationSpeed * Time.fixedDeltaTime);

            rb.MoveRotation(rb.rotation * rotationAngle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
