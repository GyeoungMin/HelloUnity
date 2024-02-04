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
    private ItemGenerator itemGenerator;
    // Start is called before the first frame update
    void Start()
    {
        this.itemGenerator = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();
        this.hp = this.maxHp;
        this.hitCoroutine = this.StartCoroutine(CoHit(() =>
        {
            this.skipCoroutine = this.StartCoroutine(this.SkipFrame(15, () =>
            {
                this.StopCoroutine(this.skipCoroutine);
                //Debug.Log(this.gameObject.ToString());
                this.ItemGenerator();
                Destroy(this.gameObject);
            }));
        }));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("PlayerBullet"))
        {
            SetState(State.Hit);
            this.hp -= collider.GetComponent<BulletController>().Damage;
            //this.hp -= 1f;
        }
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
                    this.skipCoroutine = this.StartCoroutine(this.SkipFrame(5, () =>
                    {
                        this.StopCoroutine(skipCoroutine);
                        if (this.hp <= 0)
                        {
                            SetState(State.Explosion);
                            Destroy(this.GetComponent<Rigidbody2D>());
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
    private void ItemGenerator()
    {
        if (this.transform.CompareTag("EnemyC"))
        {
            this.itemGenerator.ItemInstantiate(this.transform.position);
        }
        if (this.transform.CompareTag("EnemyB"))
        {
            float isItem = Random.Range(0, 6);
            Debug.Log(isItem);
            if (isItem == 0)
            {
                this.itemGenerator.GetComponent<ItemGenerator>().ItemInstantiate(this.transform.position);
            }
        }
    }
    //public void Hit(float damage)
    //{
    //    SetState(State.Hit);
    //    this.hp -= damage;
    //}
}
