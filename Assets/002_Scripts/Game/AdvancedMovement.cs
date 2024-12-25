using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]

public class AdvancedMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3.0f;

    [SerializeField]
    float lookSpeed = 5.0f;

    [SerializeField]
    bool intertYRotation = false; //Y軸逆回転フラグ

    [SerializeField]
    float jumpForce = 5.0f;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    bool useColliderForGroundCheck = false;//Colliderの当たり判定でジャンプの離陸・着陸判定を行う

    Rigidbody rb;
    Vector2 moveInput;
    Vector2 lookInput;
    bool jumpInput;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = true;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        Move();
        Look();
        Jump();
    }

    public void OnMove(InputValue inputValue)
    {
        //Debug.Log("OnMove");
        //Debug.Log($"OnMove {inputValue.Get<Vector2>()}");
        moveInput = inputValue.Get<Vector2>();
    }

    void Move()
    {
        //入力情報(Vector2)をVector3にプロット
        Vector3 moveDirection;　//(3次元空間内で)移動方向
        moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        //　移動
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    public void OnLook(InputValue inputValue)
    {
        //Debug.Log("OnLook");
        //Debug.Log($"OnLook {inputValue.Get<Vector2>()}");
        lookInput = inputValue.Get<Vector2>();
    }

    void Look()
    {
        //回転量をVector3(オイラー角)にプロット
        Vector3 lookDirection;//回転する方向
        lookDirection = transform.up * lookInput.x;//Y軸基点に回転(0.0f,**.**f,0.0f)

        //回転のインバート設定
        lookDirection *= intertYRotation ? -1 : 1;

        //オイラー角の回転情報をQuaternionに変換
        Quaternion rotationAngle;
        rotationAngle = Quaternion.Euler(lookDirection * lookSpeed * Time.fixedDeltaTime);

        //Quaternion　を合成し、回転
        rb.MoveRotation(rotationAngle * rb.rotation);
    }

    
    // Update is called once per frame

    public void OnJump()
    {
        Debug.Log("OnJump");
        if(!useColliderForGroundCheck)
        {
            grounded = isGrounded();
        }
        if(grounded)//接地していればジャンプできる
        {
            jumpInput = true;
        }
    }

    bool isGrounded()
    {
        bool result = false;

        //自身のCapsuleColliderを取得
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();

        //CapsuleCollider　の底部座標を取得
        Vector3 capsuleBottom = new Vector3(capsuleCollider.bounds.center.x,
                                            capsuleCollider.bounds.min.y,   //底部なので高さは最低値
                                            capsuleCollider.bounds.center.z);

        //Capsleの底部の先端で判定
        result = Physics.CheckSphere(capsuleBottom, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);

        //練習用
        //CapsuleCollider　の底部座標を取得
        //capsuleBottom.y = capsuleCollider.bounds.center.y;

        //result = Physics.CheckSphere(capsuleBottom, 0.5f, groundLayer, QueryTriggerInteraction.Ignore);

        return result;
    }

    void Jump()
    {
        if(jumpInput)
        {
            //ForceMode.Impulse: 物体の質量は考慮して、瞬間に力の大きさを最大にする
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        jumpInput = false;
    }

    void　OnCollisionEnter(Collision collision)
    {
        if(useColliderForGroundCheck)
        { 
            //衝突の相手がgroundLayerで指定したLayerに属するかチェック
            if(((1 << collision.gameObject.layer) & groundLayer)!= 0)
            {
               //着地したので再度ジャンプOK
               grounded = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (useColliderForGroundCheck)
        {
            //衝突の相手がgroundLayerで指定したLayerに属するかチェック
            if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            {
                //離陸したのでジャンプNG
                grounded = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (useColliderForGroundCheck)
        {
            //衝突の相手がgroundLayerで指定したLayerに属するかチェック
            if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            {
                //着地したので再度ジャンプOK
                grounded = true;
            }
        }
    }

    //public void OnFire(InputValue inputValue)
    //{
    //Debug.Log("OnFire");
    //    Debug.Log($"OnFire {inputValue.Get<Vector2>()}");
    //}
    void Update()
    {
        
    }

    //Input Actions を使用するには、
    //public void OnXXX(Input Valuue xxx)というメソッドを作成する

    //WASD　or　矢印キー

    
}
