using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //�������� ������
    [SerializeField]
    private GameObject[] branches; //������ ������Ʈ�� ���� �迭
    //������ ������Ʈ ����
    //�������� n��° ������Ʈ ���̶���Ʈ
    //�ٵ� �̰� �׳� �����ϸ鼭 ǥ�ĳ���� �����ʳ�??
    //����ü??
    
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
            //�������� ���� ������Ʈ
            branch_struct.branch_List.Add(Instantiate(branches[rand]));
        }    
    }

}
