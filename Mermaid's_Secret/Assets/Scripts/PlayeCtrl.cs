using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayeCtrl : MonoBehaviour
{
    //�̵� ���۰��� 
    private float h;
    private float v;
    private float r;
    private Transform tr;
    private float speed = 4f; //���߿� �ۺ����� ������Ҽ���
                              //������ ������ ���Ҽ��� ������
    [SerializeField]
    private float turnSpeed = 650f; //���콺 ȸ���ӵ�
    [SerializeField]
    private float upPower = 1f; //����� �ӵ�
    Rigidbody rb;

    [SerializeField]
    private float mouse_speedX = 3.0f;    //���콺 �¿�
    [SerializeField]
    private float mouse_speedY = 3.0f;
    private float rotationY = 0f;


    //�ִϸ��̼�
    private Animator swimAnim;
    private void Awake()
    {
        tr = this.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody>();
        swimAnim = this.GetComponent<Animator>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        SetForMove();
    }

    void LateUpdate()
    {

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouse_speedX;      // ���콺 �¿� ȸ�� ��Ű�� �̺�Ʈ

        //���콺 ���� �����̱�
        rotationY -= Input.GetAxis("Mouse Y") * mouse_speedY;    // +=�� �ϸ� ���콺 ���� ���Ϸ� �ٲ�Ե�
        rotationY = Mathf.Clamp(rotationY, -20.0f, 60.0f);       //���� ���� ���� ��Ű��, �ֳ��ϸ� ���� ���ϴµ� 360���� ���⶧��.

        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
    }
    //�⺻ �̵�, ���۰��� �Լ�
    void SetForMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        dir = dir.normalized;
        tr.Translate(dir * speed * Time.deltaTime, Space.Self);

        if (v == 0 && h == 0)
            swimAnim.SetBool("move", false);
        else
            swimAnim.SetBool("move", true);
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(Vector3.up * upPower, ForceMode.Impulse);

        //�÷��̾� �̵����� ���� ����
        float canMoveX = Mathf.Clamp(this.transform.position.x, 18f,125f);
        float canMoveY = Mathf.Clamp(this.transform.position.y, 1f, 10f);
        //������ ��ȯ�ɶ� üũ �ʿ�
        float canMoveZ = Mathf.Clamp(this.transform.position.z,8f, 130f);
        
        this.transform.position = new Vector3(canMoveX, canMoveY, canMoveZ);

    }


}
