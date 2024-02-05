using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Main : MonoBehaviour
{
    //[SerializeField] private Transform cubeTransform;
    [SerializeField] private Transform basketTransform;


    void Update()
    {
        //화면을 클릭하면 레이를 발사
        if (Input.GetMouseButtonDown(0))
        {
            //픽셀 좌표를 가지고 월드안에서 레이 객체를 만든다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //레이 개개체가 가지고있는 속성
            // ray.origin : 시작 위치
            // ray.direction : 방향
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
