using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    TextMeshProUGUI hpMessage;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject bulletPrefabPos;

    [SerializeField]
    Transform muzzlePosition;

    [SerializeField]
    private int hp = 5;

    public int Hp //�v���p�e�B
    {
        get { return hp; }
        set 
        {
            if(0 < hp)
            {
                //�����ϓ�����
                hp= value;
                //Debug.Log($"HP: {hp}");
                hpMessage.text = $"HP: {hp}";
                gameManager.PlayerAlive = true;
            }
            if(hp <= 0)
            {
                //���񂾂Ƃ��̏���
                Debug.Log("���S�I");
                gameManager.PlayerAlive = false;

            }
        }
    }

    public void OnFire(InputValue imputValue)
    {
        //this.Hp-=1;�@//�f�o�b�O�p�F�����_���[�W

        if(muzzlePosition != null)
        {
            var bulletObject = Instantiate(bulletPrefab, muzzlePosition.position, transform.rotation);
        }
        else
        {
            //bullet�v���n�u��gameObject ����݂őO��1m�@�ɁA
            //�@gameObject�Ɠ��������Ő���
            Instantiate(bulletPrefab,
                       transform.TransformPoint(Vector3.forward),
                     transform.rotation);

            //GameObject temp = Instantiate(bulletPrefab, bulletPrefabPos.transform.position, Quaternion.identity);   

            //temp.GetComponent<Rigidbody>().AddForce(transform.forward * 800);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        //HP�����l
        Hp = hp;
        bulletPrefabPos = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
