using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

enum State
{
    Idle, Run, Jump
}

public class BombGuyController : MonoBehaviour
{
    //BombGuyController�� Animator ������Ʈ�� �˾ƾ��Ѵ�.
    //Animator������Ʈ�� �ڽ� ������Ʈ anim�� �پ� �ִ�
    //��� �ϸ� �ڽĿ�����Ʈ�� �پ� �ִ� Animator������Ʈ�� �����ü� ������?
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] Animator anim;
    [SerializeField] Transform flagTransform;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 500f;
    private Coroutine coroutine;


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
        this.coroutine = this.StartCoroutine(this.CoMove(() =>
        {
            Debug.Log("�̵��� �Ϸ��Ͽ����ϴ�.");
        }));
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //�ڷ�ƾ ���߱�
        //    StopCoroutine(this.coroutine);
        //}

        //Debug.Log("Update");
        //this.coroutine = StartCoroutine(this.CoMove(() => { }));
    }

    IEnumerator CoMove(System.Action callback)
    {
        //�� �����Ӹ��� ������ �̵�
        while (true)
        {
            float directionX = 0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (this.rbody.velocity.y == 0f)
                {
                    Debug.Log("Jump");
                    this.rbody.AddForce(this.transform.up * this.jumpSpeed);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Left");
                directionX = -1f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Right");
                directionX = 1f;
            }

            if (directionX != 0f)
            {
                this.transform.localScale = new Vector3(directionX, 1f, 1f);
                this.anim.SetInteger("State", (int)State.Run);
            }
            else if (this.rbody.velocity.x == 0f && this.rbody.velocity.y == 0f)
            {
                this.anim.SetInteger("State", (int)State.Idle);
            }
            else if (this.rbody.velocity.y != 0f)
            {
                this.anim.SetInteger("State", (int)State.Jump);
            }
            //Debug.Log(this.rbody.velocity);
            if (Mathf.Abs(this.rbody.velocity.x) < 5f)
            {
                this.rbody.AddForce(this.transform.right * directionX * this.moveSpeed);
            }
            float clampX = Mathf.Clamp(transform.position.x, -8f, 8f);
            Vector3 pos = this.transform.position;
            pos.x = clampX;
            this.transform.position = pos;
            yield return null; //�������������� �Ѿ��.

            float length = this.flagTransform.position.x - this.transform.position.x;
            //Debug.LogFormat("�̵���.. �����Ÿ�  : {0}", length);
            if (length < 1)
            {
                this.anim.SetInteger("State", (int)State.Idle);
                break;  //while���� ����� 
            }
        }
        Debug.Log("�̵��Ϸ�");
        callback();
    }

    IEnumerator CoJump(System.Action callback)
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (this.rbody.velocity.y == 0f)
                {
                    Debug.Log("Jump");
                    this.rbody.AddForce(transform.up * jumpSpeed);
                }
            }
            yield return null;

        }
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
