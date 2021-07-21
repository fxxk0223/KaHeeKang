using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayeCtrl : MonoBehaviour
{
    //이동 조작관련 
    private float h;
    private float v;
    private float r;
    private Transform tr;
    private float speed = 4f; //나중에 퍼블릭으로 해줘야할수도
                              //아이템 먹으면 변할수도 잇응게
    [SerializeField]
    private float turnSpeed = 650f; //마우스 회전속도
    [SerializeField]
    private float upPower = 1f; //고도상승 속도
    Rigidbody rb;

    [SerializeField]
    private float mouse_speedX = 3.0f;    //마우스 좌우
    [SerializeField]
    private float mouse_speedY = 3.0f;
    private float rotationY = 0f;


    //애니메이션
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

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouse_speedX;      // 마우스 좌우 회전 시키는 이벤트

        //마우스 상하 움직이기
        rotationY -= Input.GetAxis("Mouse Y") * mouse_speedY;    // +=로 하면 마우스 반전 상하로 바뀌게됨
        rotationY = Mathf.Clamp(rotationY, -20.0f, 60.0f);       //상하 범위 제한 시키기, 왜냐하면 위로 향하는데 360도로 돌기때문.

        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
    }
    //기본 이동, 조작관련 함수
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

        //플레이어 이동가능 범위 제한
        float canMoveX = Mathf.Clamp(this.transform.position.x, 18f,125f);
        float canMoveY = Mathf.Clamp(this.transform.position.y, 1f, 10f);
        //육지씬 전환될때 체크 필요
        float canMoveZ = Mathf.Clamp(this.transform.position.z,8f, 130f);
        
        this.transform.position = new Vector3(canMoveX, canMoveY, canMoveZ);

    }


}
