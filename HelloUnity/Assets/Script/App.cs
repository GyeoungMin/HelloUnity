using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class App : MonoBehaviour
{
    ////���� ���� ����
    //public enum ePlatformType
    //{
    //    PC, Android, IOS
    //}
    //[SerializeField]
    //private ePlatformType platformType;

    ////��� ����
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

    //private void Awake(/*�Ű�����*/)
    //{
    //    //��������
    //    Debug.Log("Awake");
    //    Debug.LogFormat("hp : {0}", hp);    //hp : 10
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //    Debug.Log("Start");
    //    Debug.LogFormat("hp : {0}", hp);    //hp : 10
    //    //Weapon weapon = new Weapon();
    //    //Ŭ������ ���� �ν��Ͻ�(������Ʈ)�� �پ� �ִ� ���ӿ�����Ʈ
    //    //this.gameObject
    //    //App������Ʈ�� �پ� �ִ� ���ӿ�����Ʈ�� Ʈ������ ������Ʈ
    //    //this.gameObject.transform
    //    //App������Ʈ�� �پ� �ִ� ���ӿ�����Ʈ�� Ʈ������ ������Ʈ�� position �Ӽ�
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


    //    Debug.LogFormat("a : {0}", a);  //transform�� �ν��Ͻ�
    //    //a������ ���� Transform������Ʈ�� �پ� �ִ� ���ӿ�����Ʈ�� �˰� �ʹ�.
    //    Debug.LogFormat("a.gameObject: {0}", a.gameObject);

    //    //App �ν��Ͻ�
    //    //this.gameObject.transform
    //    Debug.LogFormat("b : {0}", b);

    //    //�� ������ ���� ����
    //    //���� ��� : ���� ���� (���ο�)
    //    //Vector3 c = b.position - a.position;
    //    //Debug.LogFormat("c : {0}", c);  //����
    //    //DrawArrow.ForDebug(a.position, c, 10, Color.red, ArrowType.Solid);

    //    Vector3 c1 = a.position - b.position;
    //    Debug.LogFormat("c1 : {0}", c1);
    //    DrawArrow.ForDebug(b.position, c1, 10, Color.red, ArrowType.Solid);

    //    Debug.LogFormat("c1.magnitude: {0}", c1.magnitude); //������ ���̸� ��ȯ
    //    Vector3 nomal = c1.normalized; //���� ���� (���̰� 1�� ���� : ����)

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
        // ���� * �ӵ� * �ð�
        //Vector3 pos = new Vector3(0.001f, 0, 0); //����� �ӵ��� ��Ÿ����.
        //playerGo.transform.position += pos;

        //Vector3.right * 1 * Time.deltaTime;   // ���� * �ӵ� * �ð�
        //playerGo.transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
}
