using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{
    [SerializeField] private float pMaxSpeed = 0.1f;
    [SerializeField] private float rMaxSpeed = 0.1f;
    [SerializeField] private float divied = 1920f;
    [SerializeField] private float attenAttenuation = 0.96f;
    private float pSpeed;
    private float rSpeed;
    private Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ȭ���� ��ġ �Ͽ����ϴ�.");
            this.startPoint = Input.mousePosition;
            Debug.Log(startPoint);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("ȭ���� ��ġ�� �����Ͽ����ϴ�.");
            float length = Input.mousePosition.y - startPoint.y;
            this.pSpeed = length / divied;
            this.rSpeed = pSpeed * 180;
        }

        //���� �ӵ� �ð�
        //this.gameObject.transform.position += new Vector3(0, pSpeed, 0);
        this.gameObject.transform.Translate(new Vector3(0, pSpeed, 0), Space.World);
        this.gameObject.transform.Rotate(0, 0, rSpeed);
        pSpeed *= attenAttenuation;
        rSpeed *= attenAttenuation;
    }
}
