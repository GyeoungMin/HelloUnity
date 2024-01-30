using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    [SerializeField]
    private Transform roulette;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    private float attenuation = 0.96f;

    private float speed = 0;

    //1. 마우스 왼쪽 클릭을 하면
    //2. 회전한다
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Down!");
            speed = maxSpeed;
        }
        Vector3 rotate = new Vector3(0, 0, 1);
        roulette.transform.Translate(rotate * speed * Time.deltaTime);
        //roulette.Rotate(0, 0, speed);
        speed *= 0.96f;
        Debug.Log(speed);

    }
}
