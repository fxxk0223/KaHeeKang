using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //나뭇가지 아이템
    [SerializeField]
    private GameObject[] branches; //생성할 오브젝트를 담을 배열
    //생성된 오브젝트 보관
    //랜덤으로 n번째 오브젝트 하이라이트
    //근데 이건 그냥 생성하면서 표식남기면 되지않나??
    //구조체??
    
    struct BRANCH
    {    
        public List<GameObject> branch_List;
        public bool IsItem;
    }

    BRANCH branch_struct;
    private void Start()
    {
        
    }
    void makinBranch()
    {
        int count = 0;
        while(count <10)
        {
            int rand = Random.Range(0, 3);
            float ranX = Random.Range(40f, 130f);
            float ranZ = Random.Range(40f, 150f);
            branches[rand].transform.position = new Vector3(ranX, 0.3f, ranZ);
            //랜덤으로 뽑힌 오브젝트
            branch_struct.branch_List.Add(Instantiate(branches[rand]));
        }    
    }

}
