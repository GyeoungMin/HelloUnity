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
    private Coroutine moveCoroutine;
    private Coroutine shootCoroutine;
    private State state;
    // Start is called before the first frame update
    void Start()
    {
        this.moveCoroutine = this.StartCoroutine(CoMove());
        this.shootCoroutine = this.StartCoroutine(CoMove());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Jump"));
    }

    IEnumerator CoMove()
    {
        while (true)
        {
            float speed = this.maxSpeed;
            float hMove = Input.GetAxisRaw("Horizontal");
            float vMove = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3 (hMove, vMove,0);
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

    void SetState(State state)
    {
        if (this.state != state)
        {
            this.state = state;
            this.anim.SetInteger("State", (int)state);
        }
    }

}
