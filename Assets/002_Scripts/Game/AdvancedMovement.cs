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
    bool intertYRotation = false; //Y���t��]�t���O

    [SerializeField]
    float jumpForce = 5.0f;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    bool useColliderForGroundCheck = false;//Collider�̓����蔻��ŃW�����v�̗����E����������s��

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
        //���͏��(Vector2)��Vector3�Ƀv���b�g
        Vector3 moveDirection;�@//(3������ԓ���)�ړ�����
        moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        //�@�ړ�
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
        //��]�ʂ�Vector3(�I�C���[�p)�Ƀv���b�g
        Vector3 lookDirection;//��]�������
        lookDirection = transform.up * lookInput.x;//Y����_�ɉ�](0.0f,**.**f,0.0f)

        //��]�̃C���o�[�g�ݒ�
        lookDirection *= intertYRotation ? -1 : 1;

        //�I�C���[�p�̉�]����Quaternion�ɕϊ�
        Quaternion rotationAngle;
        rotationAngle = Quaternion.Euler(lookDirection * lookSpeed * Time.fixedDeltaTime);

        //Quaternion�@���������A��]
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
        if(grounded)//�ڒn���Ă���΃W�����v�ł���
        {
            jumpInput = true;
        }
    }

    bool isGrounded()
    {
        bool result = false;

        //���g��CapsuleCollider���擾
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();

        //CapsuleCollider�@�̒ꕔ���W���擾
        Vector3 capsuleBottom = new Vector3(capsuleCollider.bounds.center.x,
                                            capsuleCollider.bounds.min.y,   //�ꕔ�Ȃ̂ō����͍Œ�l
                                            capsuleCollider.bounds.center.z);

        //Capsle�̒ꕔ�̐�[�Ŕ���
        result = Physics.CheckSphere(capsuleBottom, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);

        //���K�p
        //CapsuleCollider�@�̒ꕔ���W���擾
        //capsuleBottom.y = capsuleCollider.bounds.center.y;

        //result = Physics.CheckSphere(capsuleBottom, 0.5f, groundLayer, QueryTriggerInteraction.Ignore);

        return result;
    }

    void Jump()
    {
        if(jumpInput)
        {
            //ForceMode.Impulse: ���̂̎��ʂ͍l�����āA�u�Ԃɗ͂̑傫�����ő�ɂ���
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        jumpInput = false;
    }

    void�@OnCollisionEnter(Collision collision)
    {
        if(useColliderForGroundCheck)
        { 
            //�Փ˂̑��肪groundLayer�Ŏw�肵��Layer�ɑ����邩�`�F�b�N
            if(((1 << collision.gameObject.layer) & groundLayer)!= 0)
            {
               //���n�����̂ōēx�W�����vOK
               grounded = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (useColliderForGroundCheck)
        {
            //�Փ˂̑��肪groundLayer�Ŏw�肵��Layer�ɑ����邩�`�F�b�N
            if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            {
                //���������̂ŃW�����vNG
                grounded = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (useColliderForGroundCheck)
        {
            //�Փ˂̑��肪groundLayer�Ŏw�肵��Layer�ɑ����邩�`�F�b�N
            if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            {
                //���n�����̂ōēx�W�����vOK
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

    //Input Actions ���g�p����ɂ́A
    //public void OnXXX(Input Valuue xxx)�Ƃ������\�b�h���쐬����

    //WASD�@or�@���L�[

    
}
