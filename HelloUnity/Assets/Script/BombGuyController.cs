using System.Collections;
using UnityEngine;

enum State
{
    Idle, Run, Jump
}

public class BombGuyController : MonoBehaviour
{
    //BombGuyController�� Animator ������Ʈ�� �˾ƾ��Ѵ�.
    //Animator������Ʈ�� �ڽ� ������Ʈ anim�� �پ� �ִ�
    //��� �ϸ� �ڽĿ�����Ʈ�� �پ� �ִ� Animator������Ʈ�� �����ü� ������?
    [SerializeField] Animator anim;
    [SerializeField] Transform flagTransform;

    private Coroutine coroutine;
    private int isJumpUp = 0;
    private int isJumpDown = 2;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    void Start()
    {
        Debug.Log("Start");
        //Transform animTransform = this.transform.Find("anim");
        //GameObject animGo = animTransform.gameObject;
        //this.anim = animGo.GetComponent<Animator>();
        //Debug.LogFormat("coroutine : {0}", this.coroutine);
        //�ڷ�ƾ �Լ� ȣ���
        //this.coroutine = this.StartCoroutine(this.CoMove(() =>
        //{
        //    Debug.Log("�̵��� �Ϸ��Ͽ����ϴ�.");
        //}));

    }
    IEnumerator CoMove(System.Action callback)
    {
        //�� �����Ӹ��� ������ �̵�
        while (true)
        {
            this.transform.Translate(transform.right * 1f * Time.deltaTime);
            float length = this.flagTransform.position.x - this.transform.position.x;
            Debug.LogFormat("�̵���.. �����Ÿ� : {0}", length);
            if (length < 1)
            {
                break;
            }
            yield return null; //�������������� �Ѿ��.
        }
        Debug.Log("�̵��Ϸ�");
        callback();
    }

    IEnumerator CoJump(System.Action callback)
    {
        while (true)
        {
            float jump = 0f;
            if (this.transform.position.y == 2f)
            {
                jump = -2f;
            }
            if (this.transform.position.y == 0f)
            {
                jump = 2f;
            }
            this.transform.Translate(transform.up * jump *  Time.deltaTime);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //�ڷ�ƾ ���߱�
        //    StopCoroutine(this.coroutine);
        //}

        Debug.Log("Update");
        this.Move();
    }

    private void Move()
    {
        //�ִϸ��̼� ��ȯ �ϱ�
        //��ȭ �Ҷ� �Ķ������ ���� �����ϱ�
        Vector3 pos = this.transform.position;
        float move = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
            move = -0.1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            move = 0.1f;
        }

        //if (this.isJumpUp == 1 || this.isJumpUp == 2)
        //{
        //    pos.y += 1f;
        //    this.isJumpUp += 1;
        //    this.isJumpDown -= 1;
        //}
        //else if (this.isJumpDown == 0 || this.isJumpDown == 1)
        //{
        //    pos.y -= 1f;
        //    this.isJumpDown += 1;
        //    this.isJumpUp -= 1;
        //}
        //else if (this.isJumpUp == 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        pos.y += 1f;
        //        anim.SetInteger("State", (int)State.Jump);
        //        this.isJumpUp = +1;
        //    }
        //}
        pos.x += move;
        this.transform.Translate(pos * Time.deltaTime);
        float clampX = Mathf.Clamp(pos.x, -8f, 8f);
        pos.x = clampX;
        this.transform.position = pos;

        if (move == 0f)
        {
            this.anim.SetInteger("State", (int)State.Idle);
        }
        else if (Mathf.Abs(move) == 0.1f)
        {
            this.anim.SetInteger("State", (int)State.Run);
        }

    }
}
