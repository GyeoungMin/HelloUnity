using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainController : MonoBehaviour
{
    public enum State
    {

        Idle, Hit, Die
    }

    [SerializeField] private Animator anim;

    private float hitAnimLength = 0.133f;
    private float dieAnimLength = 0.133f;

    private State state;
    private float delta = 0;
    private int maxHp = 2;
    private int hp;
    private Coroutine hitCoroutine;
    private Coroutine stateCoroutine;
    private Set_State setstate;
    private void Start()
    {
        setstate = (State state) => {
            if (this.state != state)
            {
                this.state = state;
                this.anim.SetInteger("State", (int)this.state);
            }
        };

        this.hp = this.maxHp;
        Debug.LogFormat("{0}/{1}", this.hp, this.maxHp);
        this.setstate(State.Idle);
        this.hitCoroutine = this.StartCoroutine(this.CoHit(() =>
        {
            this.StopCoroutine(this.hitCoroutine);
            Debug.Log("적을 처치하였습니다.");
        }));
        this.stateCoroutine = this.StartCoroutine(this.CoState(() => { Debug.Log(this.anim); }));

    }

    void Update()
    {
        //this.StopCoroutine(this.hitCoroutine);
    }
    IEnumerator CoHit(System.Action callback)
    {
        while (true)
        {
            Debug.Log("CoHit");
            if (Input.GetMouseButtonUp(0))
            {
                this.hp -= 1;
                Debug.LogFormat("{0}/{1}", this.hp, this.maxHp);
                this.setstate(State.Hit);
            }
            if (this.hp <= 0)
            {
                break;
            }
            yield return null;
        }
        Debug.Log("적 처치");
        callback();
    }

    IEnumerator CoState(System.Action callback)
    {
        while (true)
        {
            switch (this.state)
            {
                case State.Idle:
                    break;
                case State.Hit:
                    this.delta += Time.deltaTime;
                    if (this.delta > this.hitAnimLength)
                    {
                        this.delta = 0;
                        if (this.hp <= 0)
                        {
                            setstate(State.Die);
                            //this.SetState(State.Die);
                        }
                        else
                        {
                            setstate(State.Idle);
                            //this.SetState(State.Idle);
                        }
                    }
                    break;
                case State.Die:
                    this.delta += Time.deltaTime;
                    if (this.delta > this.hitAnimLength)
                    {
                        this.delta = 0;
                        Destroy(this.gameObject);
                    }
                    break;
            }
            yield return null;
        }
        callback();
    }


    //private void SetState(State state)
    //{
    //    if (this.state != state)
    //    {
    //        this.state = state;
    //        this.anim.SetInteger("State", (int)this.state);
    //    }

    //}

    private delegate void Set_State(State state);
}
