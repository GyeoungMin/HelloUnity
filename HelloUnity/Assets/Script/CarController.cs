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
        //왼쪽 버튼을 눌렀다면
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("화면 터치 함");
            Debug.Log(Input.mousePosition);
            //speed = maxSpeed;
            startPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("화면에서 손을 뗌");
            Debug.Log(Input.mousePosition);
            //터치한 지점
            //화면에서 손을 뗀 지점 x - 터치한 지점의 x
            float length = Input.mousePosition.x - this.startPosition.x;
            Debug.Log(length);

            Debug.Log(length / divied);
            speed = length / divied;
            Debug.LogFormat("<color=yellow>speed : {0}</color>", speed);

            //사운드 실행

            //게임 오브젝트에 붙어 있는 컴포넌트 가져오기
            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.Play();
        }

        //0.1유닛씩 매 프레임마다 이동한다.
        Vector3 move = new Vector3(speed, 0, 0);
        this.mainCameraGo.transform.Translate(move);
        this.gameObject.transform.Translate(move);

        //매 프레임 마다 스피드를 감속 한다.
        speed *= attenuation;

        
    }
}
