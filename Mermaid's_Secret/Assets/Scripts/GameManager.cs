using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //#������
    
    //1) ����
    [SerializeField]
    GameObject bubble; //����������   

    private void Start()
    {
        makin_Bubble();
    }

    //������ġ�� �������
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
