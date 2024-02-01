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
    //BombGuyController가 Animator 컴포넌트를 알아야한다.
    //Animator컴포넌트는 자식 오브젝트 anim에 붙어 있다
    //어떻게 하면 자식오브젝트에 붙어 있는 Animator컴포넌트를 가져올수 있을까?
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
        //코루틴 함수 호출시
        this.coroutine = this.StartCoroutine(this.CoMove(() =>
        {
            Debug.Log("이동을 완료하였습니다.");
        }));
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //코루틴 멈추기
        //    StopCoroutine(this.coroutine);
        //}

        //Debug.Log("Update");
        //this.coroutine = StartCoroutine(this.CoMove(() => { }));
    }

    IEnumerator CoMove(System.Action callback)
    {
        //매 프레임마다 앞으로 이동
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
            yield return null; //다음프레임으로 넘어간다.

            float length = this.flagTransform.position.x - this.transform.position.x;
            //Debug.LogFormat("이동중.. 남은거리  : {0}", length);
            if (length < 1)
            {
                this.anim.SetInteger("State", (int)State.Idle);
                break;  //while문을 벗어난다 
            }
        }
        Debug.Log("이동완료");
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
        //애니메이션 전환 하기
        //전화 할때 파라미터의 값을 변경하기
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
