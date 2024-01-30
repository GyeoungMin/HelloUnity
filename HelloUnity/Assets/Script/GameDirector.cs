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
        Debug.LogFormat("this.carGo : {0}", this.carGo);  //car ���ӿ�����Ʈ �ν��Ͻ�
        this.flag = GameObject.Find("flag");
        Debug.LogFormat("this.flag : {0}", this.flag);  //flag ���ӿ�����Ʈ �ν��Ͻ�
        this.distanceGo = GameObject.Find("distance");
        Debug.LogFormat("this.distanceGo : {0}", this.distanceGo);  //distance ���ӿ�����Ʈ �ν��Ͻ�

        distanceText = this.distanceGo.GetComponent<Text>();
        Debug.LogFormat("distanceText: {0}", distanceText);
        distanceText.text = "�ȳ��ϼ���.";
    }

    // Update is called once per frame
    void Update()
    {
        //�������Ӹ��� �ڵ����� ����� �Ÿ��� ���
        float length = this.flag.transform.position.x - this.carGo.transform.position.x;
        Debug.Log(length);
        distanceText.text = "�����Ÿ� : " + length.ToString("F0") + "m";
    }
}
