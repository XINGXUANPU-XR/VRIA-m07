using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TransformTest : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 1.0f; //移動速度

    [SerializeField]
    float rotateSpeed = 90.0f;  //回転速度

    [SerializeField]
    bool relativeToWorld;   //ワールド空間の座標か、ローカル空間の座標が切り替えるフラグ
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Space relativeTo = SelectWorldOrLocal();

        TranslateMovement(relativeTo);

        RotateRotation();
    }

    Space SelectWorldOrLocal()
    {
        Space relativeTo;
        if(relativeToWorld)
        {
            relativeTo = Space.World;
        }
        else
        {
            relativeTo = Space.Self;
        }
        return relativeTo;
    }

    void TranslateMovement(Space relativeTo)
    {
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        { 
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime,relativeTo);
        }
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Translate(Vector3.right * (-1) * moveSpeed * Time.deltaTime, relativeTo);
        }

        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            transform.Translate(Vector3.forward * (-1) * moveSpeed * Time.deltaTime, relativeTo);
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, relativeTo);
        }
    }

    void RotateRotation()
    {
        if(Keyboard.current.eKey.isPressed)
        {
            transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
        }
        if(Keyboard.current.qKey.isPressed)
        {
            transform.Rotate(transform.up * (-1) * rotateSpeed * Time.deltaTime);
        }
    }
}
