using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public enum State
    {
        Idle, LeftMove, RightMove
    }

    [SerializeField] private float maxSpeed = 0.1f;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject bulletGenerator;
    [SerializeField] private GameObject boomPrefab;

    private Transform firePoint;
    private Coroutine moveCoroutine;
    private Coroutine boomCoroutine;
    private Component fire;
    private State state;
    private float power;
    // Start is called before the first frame update
    void Start()
    {
        //this.fire = bulletGenerator.GetComponent<BulletGenerator>();
        this.firePoint = this.transform.Find("FirePoint");
        this.moveCoroutine = this.StartCoroutine(CoMove());
        this.boomCoroutine = this.StartCoroutine(CoBoomFire());
        //this.shootCoroutine = this.StartCoroutine(CoFire());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Jump"));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            //Debug.Log(collider.transform.tag);
            this.GetItem(collider.transform.tag);
        }
    }
    IEnumerator CoMove()
    {
        while (true)
        {
            float speed = this.maxSpeed;
            float hMove = Input.GetAxisRaw("Horizontal");
            float vMove = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(hMove, vMove, 0);
            switch (hMove)
            {
                case -1f:
                    SetState(State.LeftMove);
                    break;
                case 1f:
                    SetState(State.RightMove);
                    break;
                default:
                    SetState(State.Idle);
                    break;
            }
            this.transform.Translate(direction.normalized * speed * Time.deltaTime);

            float clampX = Mathf.Clamp(this.transform.position.x, -2.3f, 2.3f);
            float clampY = Mathf.Clamp(this.transform.position.y, -3.5f, 5.5f);
            //Vector3 pos = this.transform.position;
            //pos.x = clampX;
            //pos.y = clampY;
            this.transform.position = new Vector2(clampX, clampY);
            yield return null;
        }
    }
    IEnumerator CoBoomFire()
    {
        while(true)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Boom!");
                Instantiate(boomPrefab);
            }
            yield return null;
        }
    }
    private void GetItem(string name)
    {
        //Debug.Log(name);
        switch (name)
        {
            case "Boom": break;
            case "Coin": break;
            case "Power": PowerUp(); break;
        }
    }
    public float Power { get { return this.power; } }
    private void PowerUp()
    {
        if (this.power < 2)
        {
            this.power += 1f;
            bulletGenerator.GetComponent<BulletGenerator>().PowerUp();
        }
    }
    //IEnumerator CoFire()
    //{
    //    while (true)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            bulletGenerator.GetComponent<BulletGenerator>().Fire(firePoint);
    //        }
    //        yield return null;
    //    }
    //}
    void SetState(State state)
    {
        if (this.state != state)
        {
            this.state = state;
            this.anim.SetInteger("State", (int)state);
        }
    }

}
