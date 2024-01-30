using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 0.1f;
    [SerializeField] private float attenuation = 0.96f;
    [SerializeField] private float divied = 500f;
    private GameObject groundGo;
    private GameObject mainCameraGo;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float speed = 0;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        mainCameraGo = GameObject.Find("Main Camera");
        groundGo = GameObject.Find("gorund");
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� ��ư�� �����ٸ�
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ȭ�� ��ġ ��");
            Debug.Log(Input.mousePosition);
            //speed = maxSpeed;
            startPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("ȭ�鿡�� ���� ��");
            Debug.Log(Input.mousePosition);
            //��ġ�� ����
            //ȭ�鿡�� ���� �� ���� x - ��ġ�� ������ x
            float length = Input.mousePosition.x - this.startPosition.x;
            Debug.Log(length);

            Debug.Log(length / divied);
            speed = length / divied;
            Debug.LogFormat("<color=yellow>speed : {0}</color>", speed);

            //���� ����

            //���� ������Ʈ�� �پ� �ִ� ������Ʈ ��������
            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.Play();
        }

        //0.1���־� �� �����Ӹ��� �̵��Ѵ�.
        Vector3 move = new Vector3(speed, 0, 0);
        this.mainCameraGo.transform.Translate(move);
        this.gameObject.transform.Translate(move);

        //�� ������ ���� ���ǵ带 ���� �Ѵ�.
        speed *= attenuation;

        
    }
}
