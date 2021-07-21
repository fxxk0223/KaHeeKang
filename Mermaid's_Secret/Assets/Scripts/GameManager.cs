using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //#배경관련
    
    //1) 버블
    [SerializeField]
    GameObject bubble; //버블프리팹   

    private void Start()
    {
        makin_Bubble();
    }

    //랜덤위치에 버블생성
    void makin_Bubble()
    {
        int count = 0;
        while(count<13)
        {
            float ranX = Random.Range(40f, 130f);
            float ranZ = Random.Range(40f, 150f);
            bubble.transform.position = new Vector3(ranX, 0f, ranZ);
            Instantiate(bubble);
            count++;  
        }
    }

}
