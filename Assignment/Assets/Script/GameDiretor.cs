using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDiretor : MonoBehaviour
{
    private GameObject ninjaStarGo;
    private GameObject endPointGo;
    private GameObject distanceGo;
    private Text distanceText;
    // Start is called before the first frame update
    void Start()
    {
        this.ninjaStarGo = GameObject.Find("ninjastar");
        this.endPointGo = GameObject.Find("endpoint");
        this.distanceGo = GameObject.Find("distance");
        distanceText = this.distanceGo.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = endPointGo.transform.position - ninjaStarGo.transform.position;
        distanceText.text = "남은 거리 : " + distance.y.ToString("F0");
    }
}
