using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject carGo;
    private GameObject flag;
    private GameObject distanceGo;
    private Text distanceText;

    // Start is called before the first frame update
    void Start()
    {
        this.carGo = GameObject.Find("car");
        Debug.LogFormat("this.carGo : {0}", this.carGo);  //car 게임오브젝트 인스턴스
        this.flag = GameObject.Find("flag");
        Debug.LogFormat("this.flag : {0}", this.flag);  //flag 게임오브젝트 인스턴스
        this.distanceGo = GameObject.Find("distance");
        Debug.LogFormat("this.distanceGo : {0}", this.distanceGo);  //distance 게임오브젝트 인스턴스

        distanceText = this.distanceGo.GetComponent<Text>();
        Debug.LogFormat("distanceText: {0}", distanceText);
        distanceText.text = "안녕하세요.";
    }

    // Update is called once per frame
    void Update()
    {
        //매프레임마다 자동차와 깃발의 거리를 계산
        float length = this.flag.transform.position.x - this.carGo.transform.position.x;
        Debug.Log(length);
        distanceText.text = "남은거리 : " + length.ToString("F0") + "m";
    }
}
