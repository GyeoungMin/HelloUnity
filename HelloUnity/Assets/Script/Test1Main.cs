using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Main : MonoBehaviour
{
    //[SerializeField] private Transform cubeTransform;
    [SerializeField] private Transform basketTransform;


    void Update()
    {
        //ȭ���� Ŭ���ϸ� ���̸� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            //�ȼ� ��ǥ�� ������ ����ȿ��� ���� ��ü�� �����.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //���� ����ü�� �������ִ� �Ӽ�
            // ray.origin : ���� ��ġ
            // ray.direction : ����
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red, 10);

            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 20))
            {
                Debug.Log(hit.point);
                //this.cubeTransform.position = hit.point;
                int x = Mathf.RoundToInt(hit.point.x);
                int z = Mathf.RoundToInt(hit.point.z);
                Debug.LogFormat("=> {0}", new Vector3(x, hit.point.y, z));
                this.basketTransform.position = new Vector3(x, hit.point.y, z);
            }
        }
    }
}
