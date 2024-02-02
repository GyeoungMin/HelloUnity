using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test0MainDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //화면의 좌표를 출력 하자.
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            DrawArrow.ForDebug(ray.origin, ray.direction);
            Debug.Log(ray.origin);
            Debug.Log(ray.direction);
            //Debug.DrawRay(ray.origin, ray.direction, Color.red, 10f);
        }
    }
}
