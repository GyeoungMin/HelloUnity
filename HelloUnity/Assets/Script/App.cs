using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class App : MonoBehaviour
{
    ////열거 형식 정의
    //public enum ePlatformType
    //{
    //    PC, Android, IOS
    //}
    //[SerializeField]
    //private ePlatformType platformType;

    ////멤버 변수
    //[SerializeField]
    //private int hp = 10;

    //[SerializeField]
    //private float exp = 11.33f;

    //[SerializeField]
    //private bool isGameOver = false;

    //[SerializeField]
    //private string appName = "MyApp";

    //[SerializeField]
    //private GameObject[] arrGameObjects;

    //[SerializeField]
    //private List<Transform> arrTransforms;

    //[SerializeField]
    //private Transform a;

    //[SerializeField]
    //private Transform b;

    //private void Awake(/*매개변수*/)
    //{
    //    //지역변수
    //    Debug.Log("Awake");
    //    Debug.LogFormat("hp : {0}", hp);    //hp : 10
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //    Debug.Log("Start");
    //    Debug.LogFormat("hp : {0}", hp);    //hp : 10
    //    //Weapon weapon = new Weapon();
    //    //클래스의 현재 인스턴스(컴포넌트)가 붙어 있는 게임오브젝트
    //    //this.gameObject
    //    //App컴포넌트가 붙어 있는 게임오브젝트의 트랜스폼 컴포넌트
    //    //this.gameObject.transform
    //    //App컴포넌트가 붙어 있는 게임오브젝트의 트랜스폼 컴포넌트의 position 속성
    //    //Vector3 pos = this.gameObject.transform.position;
    //    Vector3 pos = this.transform.position;
    //    Debug.Log(pos);
    //    Debug.Log(this);
    //    Debug.Log(this.gameObject);
    //    Debug.Log(this.transform);
    //    Debug.Log(this.transform.position);

    //    this.transform.position = new Vector3(0, 0, 1);

    //    Vector3 targetPosition = this.transform.position + new Vector3(0, 0, 1);
    //    Debug.LogFormat("targetPosition : {0}", targetPosition);


    //    Debug.LogFormat("a : {0}", a);  //transform의 인스턴스
    //    //a변수의 값인 Transform컴포넌트가 붙어 있는 게임오브젝트를 알고 싶다.
    //    Debug.LogFormat("a.gameObject: {0}", a.gameObject);

    //    //App 인스턴스
    //    //this.gameObject.transform
    //    Debug.LogFormat("b : {0}", b);

    //    //두 벡터의 뺄셈 연산
    //    //연산 결과 : 방향 벡터 (새로운)
    //    //Vector3 c = b.position - a.position;
    //    //Debug.LogFormat("c : {0}", c);  //방향
    //    //DrawArrow.ForDebug(a.position, c, 10, Color.red, ArrowType.Solid);

    //    Vector3 c1 = a.position - b.position;
    //    Debug.LogFormat("c1 : {0}", c1);
    //    DrawArrow.ForDebug(b.position, c1, 10, Color.red, ArrowType.Solid);

    //    Debug.LogFormat("c1.magnitude: {0}", c1.magnitude); //벡터의 길이를 반환
    //    Vector3 nomal = c1.normalized; //단위 벡터 (길이가 1인 벡터 : 방향)

    //    Debug.LogFormat("nomal: {0}", nomal);



    //}

    //[SerializeField]
    //private GameObject playerGo;
    //[SerializeField]
    //private float speed = 1;
    [SerializeField] private Transform b;   //child


    private void Start()
    {
        //Vector2 playerPos = new Vector2(3.0f, 4.0f);

        //playerGo.transform.position = playerPos;

        //playerPos.x += 8.0f;
        //playerPos.y += 5.0f;

        //Debug.LogFormat("playerGo.transform.positon : {0}",playerGo.transform.position);
        //Debug.LogFormat("playerPos : {0}", playerPos);

        //playerGo.transform.position = playerPos;
        //Debug.LogFormat("playerGo.transform.positon : {0}", playerGo.transform.position);

        Debug.LogFormat("b.position: {0}", b.position); //world space
        Debug.LogFormat("b.position: {0}", b.localPosition); //local space
    }
    private void Update()
    {
        // 방향 * 속도 * 시간
        //Vector3 pos = new Vector3(0.001f, 0, 0); //방향과 속도를 나타낸다.
        //playerGo.transform.position += pos;

        //Vector3.right * 1 * Time.deltaTime;   // 방향 * 속도 * 시간
        //playerGo.transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
}
