using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public enum State
    {
        Idle, Hit, Explosion
    }
    [SerializeField] private Animator anim;
    [SerializeField] private float maxHp = 2f;

    private State state;
    private Coroutine hitCoroutine;
    private Coroutine skipCoroutine;
    private float hp;
    // Start is called before the first frame update
    void Start()
    {
        this.hp = this.maxHp;
        this.hitCoroutine = this.StartCoroutine(CoHit(() =>
        {
            this.skipCoroutine = this.StartCoroutine(this.SkipFrame(5, () =>
            {
                this.StopCoroutine(skipCoroutine);
                Destroy(this.gameObject);
            }));
        }));
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        SetState(State.Hit);
        hp -= 1f;
    }

    IEnumerator CoHit(System.Action callback)
    {
        while (true)
        {
            switch (this.state)
            {
                case State.Idle:
                    break;
                case State.Hit:
                    this.skipCoroutine = this.StartCoroutine(this.SkipFrame(5,() =>
                    {
                        this.StopCoroutine(skipCoroutine);
                        if (this.hp <= 0)
                        {
                            SetState(State.Explosion);
                            this.GetComponent<PolygonCollider2D>().isTrigger = false;
                            callback();
                        }
                        else
                        {
                            SetState(State.Idle);
                        }

                    }));
                    break;
                //case State.Explosion:
                //    this.skipCoroutine = this.StartCoroutine(this.SkipFrame(15,() =>
                //    {
                //        this.StopCoroutine(skipCoroutine);
                //        Destroy(this.gameObject);
                //    }));
                //    break;
            }
            yield return null;
        }
    }
    IEnumerator SkipFrame(int length, System.Action callback)
    {
        for (int i = 0; i <= length; i++)
        {
            yield return null;
        }
        callback();
    }
    private void SetState(State state)
    {
        if (this.state != state)
        {
            this.state = state;
            this.anim.SetInteger("State", (int)this.state);
        }

    }
}
