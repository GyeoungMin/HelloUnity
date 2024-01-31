using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float jumpForce = 680f;
    [SerializeField] private float moveForce = 3f;
    [SerializeField] private ClimbCloudGameDirector gameDirector;
    [SerializeField] private GameObject flagGo;
    private Animator anim;
    private bool hasCollider = false;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.rbody.velocity.y == 0f)
            {
                //점프
                this.rbody.AddForce(this.transform.up * this.jumpForce);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            directionX = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            directionX = 1f;
        }
        if (directionX != 0f)
        {
            this.transform.localScale = new Vector3(directionX, 1f, 1f);
        }
        this.anim.speed = Mathf.Abs(this.rbody.velocity.x) / 2f;

        //도전 ! : 속도를 제한하자
        if (Mathf.Abs(this.rbody.velocity.x) < 3f)
        {
            this.rbody.AddForce(directionX * this.transform.right * moveForce);
        }
        this.gameDirector.UpdateVelocityText(this.rbody.velocity);


        float clampX = Mathf.Clamp(this.transform.position.x, -2.5f, 2.5f);
        Vector3 pos = this.transform.position;
        pos.x = clampX;
        this.transform.position = pos;

    }

    //Trigger모드일 경우 충돌 판정을 해주는 이벤트 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollider)
        {
            return;
        }
        Debug.LogFormat("Enter2D : {0}", collision);
        SceneManager.LoadScene(1);
        hasCollider = true;
    }
}
